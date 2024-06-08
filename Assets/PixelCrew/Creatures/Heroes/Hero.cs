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

namespace PixelCrew.Creatures.Heroes
{
    public class Hero : Creature
    {
        [SerializeField] private CheckCircleOverlap _interationCheck;
        [SerializeField] private LayerCheck _wallCheck;

        [SerializeField] private LayerMask _interactionLayer;

        [SerializeField] private float _slamDownVelocity;
        //[SerializeField] private float _interactionRadius;

        [SerializeField] private Cooldown _throwCooldown;
        [SerializeField] private AnimatorController _armed;
        [SerializeField] private AnimatorController _disarmed;

        [SerializeField] private float _fallVelocityforDamage;

        [Space] [Header("Particles")] 
        [SerializeField] private ParticleSystem _hitParticles;

        [SerializeField] private int _numberThrowRow;

        private bool _allowDoubleJump;
        private bool _isOnWall;

        private GameSession _session;
        private float _defaultGravityScale;
        //public GameSession Session
        //{
            //get { return _session; }
            //set { _session = value; }
        //}

        private HealthComponent healthComponent;
        private static readonly int ThrowKey = Animator.StringToHash("throw");
        private static readonly int IsOnWall = Animator.StringToHash("is-on-wall");

        private int CoinCount => _session.Data.Inventory.Count("Coin");
        private int SwordCount => _session.Data.Inventory.Count("Sword");

        public void OnDoThrow()
        {
            _particles.Spawn("Throw");
        }
        public void Throw(double duration)
        {
            if (duration >= 1d)
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
                yield return new WaitForSeconds(0.1f);
            }
        }
        private void OnThrow()
        {
            if (IsAmountSwords())
            {
                //ModifyAmountSwords(-1);
                _session.Data.Inventory.Remove("Sword", 1);
                Animator.SetTrigger(ThrowKey);
            }
        }


        protected override void Awake()
        {
            base.Awake();
            healthComponent = GetComponent<HealthComponent>();
            _defaultGravityScale = _rigidbody.gravityScale;//Возможно лишний
        }

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
            var health = GetComponent<HealthComponent>();
            _session.Data.Inventory.OnChanged += OnInentoryChanged;

            health.SetHealth(_session.Data.Hp);
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
            _session.Data.Hp = currentHealth;
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
                _particles.Spawn("Jump");
                _allowDoubleJump = false;
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
            var numCoinsToDispose = Mathf.Min(CoinCount, 5);
            _session.Data.Inventory.Remove("Coin", numCoinsToDispose);

            var burst = _hitParticles.emission.GetBurst(0);
            burst.count = numCoinsToDispose;
            _hitParticles.emission.SetBurst(0, burst);

            _hitParticles.gameObject.SetActive(true);
            _hitParticles.Play();
        }

        public void Interact()
        {
            _interationCheck.Check();
        }
        public void SayCoins()
        {
            //Debug.Log(_session.Data.Coins);
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

        //public void ArmHero()
        //{
        //    _session.Data.IsArmed = true;
        //    UpdateHeroWeapon();
        //}

        private void UpdateHeroWeapon()
        {
            Animator.runtimeAnimatorController = SwordCount > 0 ? _armed : _disarmed;
        }

        //public void ModifyAmountSwords(int amountSwords)
        //{
            //_session.Data.AmountSwords += amountSwords;
            //_session.Data.Inventory.Add(this.gameObject,"Sword", amountSwords);
        //}
        public bool IsAmountSwords()
        {
            return SwordCount > 1 ? true : false;
        }
    }
}
