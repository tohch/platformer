using PixelCrew.Components;
using PixelCrew.Model;
using PixelCrew.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.Animations;
using UnityEditor.UIElements;
using UnityEngine;
using PixelCrew.Components.ColliderBased;
using PixelCrew.Components.Health;
using PixelCrew.Model.Data;

namespace PixelCrew.Creatures.Heroes
{
    public class Hero : Creature, ICanAddInInventory
    {
        [SerializeField] private CheckCircleOverlap _interationCheck;
        [SerializeField] private ColliderCheck _wallCheck;

        [SerializeField] private LayerMask _interactionLayer;

        [SerializeField] private float _slamDownVelocity;

        [SerializeField] private Cooldown _throwCooldown;
        [SerializeField] private AnimatorController _armed;
        [SerializeField] private AnimatorController _disarmed;
        [SerializeField] private float _fallVelocityforDamage;

        [Header("Super throw")]
        [SerializeField] private double _pressTimeForSuperThrow;
        [SerializeField] private int _numberThrowRow;
        [SerializeField] private float _superThrowDelay;
        [Space]

        [SerializeField] private ProbabilityDropComponent _hitDrop;
        [SerializeField] private int _maxNumCoinsToDispose;

        [SerializeField] private ModifyHealthComponent _healPotion;

        private bool _allowDoubleJump;
        private bool _isOnWall;

        private GameSession _session;
        private float _defaultGravityScale;

        private HealthComponent healthComponent;
        private static readonly int ThrowKey = Animator.StringToHash("throw");
        private static readonly int IsOnWall = Animator.StringToHash("is-on-wall");

        private int CoinCount => _session.Data.Inventory.Count("Coin");
        private int SwordCount => _session.Data.Inventory.Count("Sword");
        

        public void OnDoThrow()
        {
            Sounds.Play("Range");
            _particles.Spawn("Throw");
        }
        public void Throw(double duration)
        {
            if (duration >= _pressTimeForSuperThrow)
            {
                StartCoroutine(ThrowRow());
            }
            else
            {
                ThrowOne();
            }
        }
        private void ThrowOne()
        {
            if (_throwCooldown.IsReady)
            {
                OnThrow();
                _throwCooldown.Reset();
            }
        }
        private IEnumerator ThrowRow()
        {
            for (int i = 0; i < _numberThrowRow; i++)
            {
                OnThrow();
                yield return new WaitForSeconds(_superThrowDelay);
            }
        }
        private void OnThrow()
        {
            if (IsAmountSwords())
            {
                _session.Data.Inventory.Remove("Sword", 1);
                Animator.SetTrigger(ThrowKey);
            }
        }


        protected override void Awake()
        {
            base.Awake();
            healthComponent = GetComponent<HealthComponent>();
            _defaultGravityScale = _rigidbody.gravityScale;
        }

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
            var health = GetComponent<HealthComponent>();
            _session.Data.Inventory.OnChanged += OnInentoryChanged;

            health.SetHealth(_session.Data.Hp.Value);
            UpdateHeroWeapon();
        }

        private void OnDestroy()
        {
            _session.Data.Inventory.OnChanged -= OnInentoryChanged;
        }
        private void OnInentoryChanged(string id, int value)
        {
            if (id == "Sword")
                UpdateHeroWeapon();
        }
        public void OnHealthChanged(int currentHealth)
        {
            _session.Data.Hp.Value = currentHealth;
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
        }
        protected override void Update()
        {
            base.Update();

            var moveToSameDirection = Direction.x * transform.lossyScale.x > 0;
            if (_wallCheck.IsTouchingLayer && moveToSameDirection)
            {
                _isOnWall = true;
                _rigidbody.gravityScale = 0;
            }
            else
            {
                _isOnWall = false;
                _rigidbody.gravityScale = _defaultGravityScale;
            }
            Animator.SetBool(IsOnWall, _isOnWall);
        }
        protected override float CalculateYVelocity()
        {
            var isJumpPressing = Direction.y > 0;
            //my
            if (_isOnWall)
            {
                _allowDoubleJump = true;
                return 0f;
            }
            //
            if (IsGrounded || _isOnWall)
            {
                _allowDoubleJump = true;
            }

            if (!isJumpPressing && _isOnWall)
            {
                return 0f;
            }
            return base.CalculateYVelocity();
        }

        protected override float CalculateJumpVelocity(float yVelocity)
        {

            if (!IsGrounded && _allowDoubleJump && !_isOnWall)
            {
                _allowDoubleJump = false;
                DoJumpVfx();
                return _jumpSpeed;
            }

            return base.CalculateJumpVelocity(yVelocity);
        }

        public void AddInInventory(string id, int value)
        {
            _session.Data.Inventory.Add(id, value);
        }

        public override void TakeDamage()
        {
            base.TakeDamage();
            if (CoinCount > 0)
            {
                SpawnCoins();
            }
        }
        private void SpawnCoins()
        {
            var numCoinsToDispose = Mathf.Min(CoinCount, _maxNumCoinsToDispose);
            _session.Data.Inventory.Remove("Coin", numCoinsToDispose);

            _hitDrop.SetCount(numCoinsToDispose);
            _hitDrop.CalculateDrop();
        }

        public void Interact()
        {
            _interationCheck.Check();
        }
        public void SayCoins()
        {
            Debug.Log(CoinCount);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.IsInLaver(_groundLayer))
            {
                var contact = other.contacts[0];
                if (contact.relativeVelocity.y >= _slamDownVelocity)
                {
                    _particles.Spawn("SpamDown");
                }
                if(contact.relativeVelocity.y >= _fallVelocityforDamage)
                {
                    healthComponent.ModifyHealth(-1);
                }
            }
        }

        public override void Attack()
        {
            if (SwordCount <= 0) return;

            base.Attack();
        }

        private void UpdateHeroWeapon()
        {
            Animator.runtimeAnimatorController = SwordCount > 0 ? _armed : _disarmed;
        }

        public bool IsAmountSwords()
        {
            return SwordCount > 1;
        }
        public void UseHealPotion()
        {
            int numRemoveHealPotion = 1;
            if (_session.Data.Inventory.Count("HealPotion") > 0)
            {
                _healPotion.Apply(this.gameObject);
                _session.Data.Inventory.Remove("HealPotion", numRemoveHealPotion);
            }
        }
    }
}
