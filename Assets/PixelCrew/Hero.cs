using PixelCrew.Components;
using PixelCrew.Utils;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.Animations;
using UnityEditor.UIElements;
using UnityEngine;

namespace PixelCrew
{
    public class Hero : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _jumpSpeed;
        [SerializeField] private float _damageJumpSpeed;

        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private float _groundCheckRadius;
        [SerializeField] private Vector3 _groundCheckPositionDelta;
        [SerializeField] private float _interactionRadius;
        [SerializeField] private LayerMask _interactionLayer;

        [SerializeField] private AnimatorController _armed;
        [SerializeField] private AnimatorController _disarmed;

        [SerializeField] private float _slamDownVelocity;
        public int _coins;

        [SerializeField] private CheckCircleOverlap _attackRange;
        [SerializeField] private int _damage;

        [Space] [Header("Particles")]
        [SerializeField] private SpawnComponent _footStepParticles;
        [SerializeField] private SpawnComponent _footJumpParticles;
        [SerializeField] private SpawnComponent _footFallParticles;
        [SerializeField] private ParticleSystem _hitParticles;

        private Collider2D[] _interactionResult = new Collider2D[1];
        private Rigidbody2D _rigidbody;
        private Vector2 _direction;
        private Animator _animator;
        private bool _isGrounded;
        private bool _allowDoubleJump;
        private bool _isTakeDamage;
        private static readonly int IsGroundKey = Animator.StringToHash("is-ground");
        private static readonly int IsRunning = Animator.StringToHash("is-running");
        private static readonly int VerticalVelocity = Animator.StringToHash("vertical-velocity");
        private static readonly int Hit = Animator.StringToHash("hit");
        private static readonly int AttackKey = Animator.StringToHash("attack");

        private bool _isArmed;

        private bool _isCarry = false;
        private List<GameObject> _objectCarry;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _objectCarry = new List<GameObject>();
        }
        public void SaySomething()
        {
            Debug.Log("Say");
        }
        private bool IsGrounded()
        {
            var hit = Physics2D.CircleCast(transform.position + _groundCheckPositionDelta, _groundCheckRadius, Vector2.down, 0, _groundLayer);
            return hit.collider != null;
        }
        private void FixedUpdate()
        {
            var xVelocity = _direction.x * _speed;
            var yVelocity = CalculateYVelocity();
            _rigidbody.velocity = new Vector2(xVelocity, yVelocity);
            _animator.SetBool(IsGroundKey, _isGrounded);
            _animator.SetFloat(VerticalVelocity, _rigidbody.velocity.y);
            _animator.SetBool(IsRunning, _direction.x != 0);
            UpdateSpriteDirection();
            OnCarry(_objectCarry, _isCarry);
        }
        private void Update()
        {
            _isGrounded = IsGrounded();
        }
        private float CalculateYVelocity()
        {
            var yVelocity = _rigidbody.velocity.y;
            var isJumpPressing = _direction.y > 0;


            if (_isGrounded) _allowDoubleJump = true;

            if (isJumpPressing)
            {
                yVelocity = CalculateJumpVelocity(yVelocity);
            }
            else if (_rigidbody.velocity.y > 0 && !_isTakeDamage)
            {
                yVelocity *= 0.5f;
            }
            return yVelocity;
        }

        private float CalculateJumpVelocity(float yVelocity)
        {
            var isFalling = _rigidbody.velocity.y <= 0.001f;
            if (!isFalling) return yVelocity;
            if (_isGrounded)
            {
                yVelocity += _jumpSpeed;
                SpawnFootJumpDust();
            }
            else if (_allowDoubleJump)
            {
                yVelocity = _jumpSpeed;
                _allowDoubleJump = false;
                SpawnFootJumpDust();
            }

            return yVelocity;
        }

        private void UpdateSpriteDirection()
        {
            if (_direction.x > 0)
            {
                transform.localScale = Vector3.one;
            }
            else if (_direction.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        internal void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }
#if UNITY_EDITOR
        void OnDrawGizmos()
        {
            Handles.color = IsGrounded() ? HandlesUtils.TransparentGreen : HandlesUtils.TransparentRed;
            Handles.DrawSolidDisc(transform.position + _groundCheckPositionDelta, Vector3.forward, _groundCheckRadius);
        }
#endif
        public void OnTakeDamageFlag()
        {
            _isTakeDamage = true;
        }
        public void OffTakeDamageFlag()
        {
            _isTakeDamage = false;
        }
        public void TakeDamage()
        {
            _animator.SetTrigger(Hit);
            var isJumpPressing = _direction.y > 0;
            if (!isJumpPressing)
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _damageJumpSpeed);

            if (_coins > 0)
            {
                SpawnCoins();
            }
        }
        private void SpawnCoins()
        {
            var numCoinsToDispose = Mathf.Min(_coins, 5);
            _coins -= numCoinsToDispose;

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
            Debug.Log(_coins);
        }

        public void SpawnFootDust()
        {
            _footStepParticles.Spawn();
        }

        public void SpawnFootJumpDust()
        {
            _footJumpParticles.Spawn();
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
                    _footFallParticles.Spawn();
                }
            }
        }

        public void Attack()
        {
            if (!_isArmed) return;

            _animator.SetTrigger(AttackKey);
        }

        public void OnAttackEnemy()
        {
            var gos = _attackRange.GetObjectsInRange();
            foreach (var go in gos)
            {
                var hp = go.GetComponent<HealthComponent>();
                if (hp != null && go.CompareTag("Enemy"))
                {
                    if (hp.Health > 0)
                        hp.ModifyHealth(-_damage);
                }
            }
        }

        public void ArmHero()
        {
            _isArmed = true;
            _animator.runtimeAnimatorController = _armed;
        }
    }
}
