using PixelCrew.Components;
using PixelCrew.Model;
using PixelCrew.Utils;
using System.Collections;
using UnityEditor.Animations;
using UnityEngine;
using PixelCrew.Components.ColliderBased;
using PixelCrew.Components.Health;
using PixelCrew.Model.Data;
using PixelCrew.Components.GoBased;
using PixelCrew.Model.Definitions;
using PixelCrew.Model.Definitions.Repositories.Items;
using PixelCrew.Model.Definitions.Repositories;
using PixelCrew.Model.Definitions.Player;
using PixelCrew.Effects.CameraRelated;

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
        private Cooldown _superThrowCooldown;
        //private bool _superThrow;
        [SerializeField] private int _numberThrowRow;
        [SerializeField] private float _superThrowDelay;
        [SerializeField] private float _meleeAttackCooldown;
        [Space]

        [SerializeField] private ProbabilityDropComponent _hitDrop;
        [SerializeField] private SpawnComponent _throwSpawner;
        [SerializeField] private int _maxNumCoinsToDispose;

        [SerializeField] private ModifyHealthComponent _healPotion;

        private HealthComponent _health;
        private bool _allowDoubleJump;
        private bool _isOnWall;

        private GameSession _session;
        private float _defaultGravityScale;
        private float _nextMeleeAttackTime;
        private CameraShakeEffect _cameraShake;

        private HealthComponent healthComponent;
        private static readonly int ThrowKey = Animator.StringToHash("throw");

        private static readonly int IsOnWall = Animator.StringToHash("is-on-wall");

        private const string SwordId = "Sword";
        private int CoinCount => _session.Data.Inventory.Count("Coin");
        private int SwordCount => _session.Data.Inventory.Count(SwordId);

        private string SelectedItemId => _session.QuickInventory.SelectedItem.Id;

        private bool CanThrow
        {
            get
            {
                if (SelectedItemId == SwordId)
                    return SwordCount > 1;

                var def = DefsFacade.I.Items.Get(SelectedItemId);
                return def.HasTag(ItemTag.Throwable);
            }
        }

        public void UseInventory()
        {
            if (IsSelectedItem(ItemTag.Throwable))
                PerformThrowing();
            else if (IsSelectedItem(ItemTag.Potion))
                UsePotion();
        }

        private void UsePotion()
        {
            var potion = DefsFacade.I.Potions.Get(SelectedItemId);
            
            switch (potion.Effect)
            {
                case Effect.AddHp:
                    _session.Data.Hp.Value += (int)potion.Value;
                    break;
                case Effect.SpeedUp:
                    _speedUpCooldown.Value = _speedUpCooldown.TimeLasts + potion.Time;
                    _additionalSpeed = Mathf.Max(potion.Value, _additionalSpeed);
                    _speedUpCooldown.Reset();
                    break;
            }
            _session.Data.Inventory.Remove(potion.Id, 1);
        }

        private readonly Cooldown _speedUpCooldown = new Cooldown();
        private float _additionalSpeed;

        protected override float CalculateSpeed()
        {
            if (_speedUpCooldown.IsReady)
                _additionalSpeed = 0f;

            var defaultSpeed = _session.StatsModel.GetValue(StatId.Speed);
            return defaultSpeed + _additionalSpeed;
        }

        private bool IsSelectedItem(ItemTag tag)
        {
            return _session.QuickInventory.SelsetedDef.HasTag(tag);
        }

        public void StartThrowing()
        {
            _superThrowCooldown.Reset();
        }

        private void PerformThrowing()
        {
            if (_superThrowCooldown.IsReady && _session.PerksModel.IsSuperThrowSupported)
            {
                //_superThrow = true;
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
                ThrowAndRemoveFromInventory();
                _throwCooldown.Reset();
            }
        }

        private IEnumerator ThrowRow()
        {
            for (int i = 0; i < _numberThrowRow; i++)
            {
                ThrowAndRemoveFromInventory();
                yield return new WaitForSeconds(_superThrowDelay);
            }
            //_superThrow = false;
        }

        public void OnDoSoundThrow()
        {
            Sounds.Play("Range");
        }

        private void ThrowAndRemoveFromInventory()
        {
            if (CanThrow)
            {
                var throwableId = _session.QuickInventory.SelectedItem.Id;
                var throwableDef = DefsFacade.I.Throwable.Get(throwableId);
                _throwSpawner.SetPrefab(throwableDef.Projectile);
                _throwSpawner.Spawn();

                _session.Data.Inventory.Remove(throwableId, 1);
                Animator.SetTrigger(ThrowKey);
            }
        }

        protected override void Awake()
        {
            base.Awake();
            healthComponent = GetComponent<HealthComponent>();
            _defaultGravityScale = Rigidbody.gravityScale;
            _superThrowCooldown = new Cooldown() { Value = (float)_pressTimeForSuperThrow };
        }

        private void Start()
        {
            _cameraShake = FindObjectOfType<CameraShakeEffect>();
            _session = FindObjectOfType<GameSession>();
            _health = GetComponent<HealthComponent>();
            _session.Data.Inventory.OnChanged += OnInentoryChanged;
            _session.StatsModel.OnUpgraded += OnHeroUpgraded;
            
            _health.SetHealth(_session.Data.Hp.Value);
            UpdateHeroWeapon();
        }

        private void OnHeroUpgraded(StatId statId)
        {
            switch (statId)
            {
                case StatId.Hp:
                    var health = (int)_session.StatsModel.GetValue(statId);
                    _session.Data.Hp.Value = health;
                    _health.SetHealth(health);
                    break;
            }
        }

        private void OnDestroy()
        {
            _session.Data.Inventory.OnChanged -= OnInentoryChanged;
        }

        private void OnInentoryChanged(string id, int value)
        {
            if (id == SwordId)
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
                Rigidbody.gravityScale = 0;
            }
            else
            {
                _isOnWall = false;
                Rigidbody.gravityScale = _defaultGravityScale;
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

            if (!IsGrounded && _allowDoubleJump && _session.PerksModel.IsDoubleJumpSupported && !_isOnWall)
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
            _cameraShake?.Shake();
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

            if(_nextMeleeAttackTime < Time.time)
            {
                base.Attack();
                _nextMeleeAttackTime = Time.time + _meleeAttackCooldown;
            }

        }

        private void UpdateHeroWeapon()
        {
            Animator.runtimeAnimatorController = SwordCount > 0 ? _armed : _disarmed;
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

        public void DropFromPlatform()
        {
            var position = transform.position;
            var endPosition = position + new Vector3(0, -1);
            var hit = Physics2D.Linecast(position, endPosition, _groundLayer);

            if (hit.collider == null) return;

            var component = hit.collider.GetComponent<TmpDisableColliderComponent>();
            if (component == null) return;

            component.DisableCollider();
        }

        public void NextItem()
        {
            _session.QuickInventory.SetNextItem();
        }
    }
}
