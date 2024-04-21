using PixelCrew.Components;
using PixelCrew.Model;
using PixelCrew.Utils;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.Animations;
using UnityEditor.UIElements;
using UnityEngine;

namespace PixelCrew.Creatures
{
    public class Hero : Creature
    {
        [SerializeField] private LayerMask _interactionLayer;
        [SerializeField] private LayerCheck _wallCheck;

        [SerializeField] private float _slamDownVelocity;
        [SerializeField] private float _interactionRadius;

        [SerializeField] private AnimatorController _armed;
        [SerializeField] private AnimatorController _disarmed;

        [SerializeField] private float _fallVelocityforDamage;

        [Space] [Header("Particles")] 
        [SerializeField] private ParticleSystem _hitParticles;

        private Collider2D[] _interactionResult = new Collider2D[1];
        
        private bool _allowDoubleJump;
        private bool _isOnWall;
        
        
        private GameSession _session;
        private float _defaultGravityScale;
        public GameSession Session 
        {
            get { return _session; }
            set { _session = value; }
        }

        private bool _isCarry = false;
        private List<GameObject> _objectCarry;
        private HealthComponent healthComponent;

        protected override void Awake()
        {
            base.Awake();
            _objectCarry = new List<GameObject>();
            healthComponent = GetComponent<HealthComponent>();
            _defaultGravityScale = _rigidbody.gravityScale;//Возможно лишний
        }

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();

            var health = GetComponent<HealthComponent>();
            health.SetHealth(_session.Data.Hp);
            UpdateHeroWeapon();
        }
        public void OnHealthChanged(int currentHealth)
        {
            _session.Data.Hp = currentHealth;
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            OnCarry(_objectCarry, _isCarry);
        }
        protected override void Update()
        {
            base.Update();

            if (_wallCheck.IsTouchingLayer && Direction.x == transform.localScale.x)
            {
                _isOnWall = true;
                _rigidbody.gravityScale = 0;
            }
            else
            {
                _isOnWall = false;
                _rigidbody.gravityScale = _defaultGravityScale;
            }
        }
        protected override float CalculateYVelocity()
        {
            var isJumpPressing = Direction.y > 0;

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
            if (!IsGrounded && _allowDoubleJump)
            {
                _particles.Spawn("Jump");
                _allowDoubleJump = false;
                return _jumpSpeed;
            }

            return base.CalculateJumpVelocity(yVelocity);
        }

        public override void TakeDamage()
        {
            base.TakeDamage();
            if (_session.Data.Coins > 0)
            {
                SpawnCoins();
            }
        }
        private void SpawnCoins()
        {
            var numCoinsToDispose = Mathf.Min(_session.Data.Coins, 5);
            _session.Data.Coins -= numCoinsToDispose;

            var burst = _hitParticles.emission.GetBurst(0);
            burst.count = numCoinsToDispose;
            _hitParticles.emission.SetBurst(0, burst);

            _hitParticles.gameObject.SetActive(true);
            _hitParticles.Play();
        }

        public void Interact()
        {
            var size = Physics2D.OverlapCircleNonAlloc(transform.position, _interactionRadius,
                                                       _interactionResult, _interactionLayer);
            for (int i = 0; i < size; i++)
            {
                var interactable = _interactionResult[i].GetComponent<InteractableComponent>();
                if (interactable != null)
                {
                    interactable.Interact(gameObject);
                }
            }
        }
        public void SayCoins()
        {
            Debug.Log(_session.Data.Coins);
        }

        public void OnCarry(List<GameObject> gameObject, bool isCarry)
        {
            if (gameObject.Count > 0)
            {
                var collider = gameObject[0].GetComponent<Collider2D>();
                var rigidbody = gameObject[0].GetComponent<Rigidbody2D>();
                if (isCarry)
                {
                    collider.enabled = false;
                    rigidbody.isKinematic = true; ;
                    gameObject[0].transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0.1f);
                }
                else if (!isCarry)
                {
                    foreach (var objectCarry in _objectCarry)
                    {
                        if (objectCarry != null && !_isCarry)
                        {
                            objectCarry.GetComponent<Collider2D>().enabled = true;
                            objectCarry.GetComponent<Rigidbody2D>().isKinematic = false;
                        }
                    }
                    _objectCarry.Clear();
                }
            }
        }
        public void SwitchCarry(GameObject gameObject)
        {
            _isCarry = !_isCarry;
            _objectCarry.Add(gameObject);
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
            if (!_session.Data.IsArmed) return;

            base.Attack();
        }

        public void ArmHero()
        {
            _session.Data.IsArmed = true;
            UpdateHeroWeapon();
        }

        private void UpdateHeroWeapon()
        {
            Animator.runtimeAnimatorController = _session.Data.IsArmed ? _armed : _disarmed;
        }
    }
}
