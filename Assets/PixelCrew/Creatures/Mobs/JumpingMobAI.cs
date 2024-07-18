using PixelCrew.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using PixelCrew.Components.ColliderBased;
using PixelCrew.Components.GoBased;
using PixelCrew.Creatures.Mobs.Patrolling;

namespace PixelCrew.Creatures.Mobs
{
    public class JumpingMobAI : MonoBehaviour
    {
        [SerializeField] private LayerCheck _vision;
        [SerializeField] private LayerCheck _canAttack;

        [SerializeField] private float _alarmDelay = 0.5f;
        [SerializeField] private float _attackCooldown = 1f;
        [SerializeField] private float _missHeroCooldown = 0.5f;
        [SerializeField] private float _hightJumpAttack;
        [SerializeField] private LayerCheck _platformCheck;

        private Coroutine _current;
        private GameObject _target;

        private static readonly int IsDeadKey = Animator.StringToHash("is-dead");

        private SpawnListComponent _particles;
        private Creature _creature;
        private Animator _animator;
        private bool _isDead;
        private Patrol _patrol;

        private void Awake()
        {
            _particles = GetComponent<SpawnListComponent>();
            _creature = GetComponent<Creature>();
            _animator = GetComponent<Animator>();
            _patrol = GetComponent<Patrol>();
        }
        private void Start()
        {
            StartState(_patrol.DoPatrol());
        }
        public void OnHeroInVision(GameObject go)
        {
            if (_isDead) return;

            _target = go;
            StartState(AgroToHero());
        }

        private IEnumerator GoToHero()
        {
            while (_vision.IsTouchingLayer && !_isDead)
            {
                if (_canAttack.IsTouchingLayer)
                {
                    StartState(Attack());
                }
                else if (_platformCheck.IsTouchingLayer)
                {
                    SetDirectionToTarget();
                }
                yield return null;
            }
            if (!_isDead)
            {
                _creature.SetDirection(Vector2.zero);
                _particles.Spawn("MissHero");
                yield return new WaitForSeconds(_missHeroCooldown);
                StartState(_patrol.DoPatrol());
            }
        }

        private IEnumerator Attack()
        {
            while (_canAttack.IsTouchingLayer)
            {
                _creature.Attack();
                yield return new WaitForSeconds(_attackCooldown);
            }
            StartState(GoToHero());
        }

        private void SetDirectionToTarget()
        {
            var direction = GetDirectionToTarget();
            _creature.SetDirection(direction);
        }

        private IEnumerator AgroToHero()
        {
            LookAtHero();
            _particles.Spawn("Exclamation");
            yield return new WaitForSeconds(_alarmDelay);
            StartState(GoToHero());
        }

        private void LookAtHero()
        {
            var direction = GetDirectionToTarget();
            _creature.SetDirection(Vector2.zero);
            _creature.UpdateSpriteDirection(direction);
        }
        private Vector2 GetDirectionToTarget()
        {
            var direction = new Vector3();
            var distanceForJumping = 2f;

            direction.x = _target.transform.position.x - transform.position.x;
            if (Math.Abs(direction.x) >= distanceForJumping)
                direction.y = _target.transform.position.y - transform.position.y + _hightJumpAttack;

            return direction.normalized;
        }

        private IEnumerator Patrolling()
        {
            yield return null;
        }
        private void StartState(IEnumerator coroutine)
        {
            _creature.SetDirection(Vector2.zero);

            if (_current != null)
                StopCoroutine(_current);
            _current = StartCoroutine(coroutine);
        }

        public void OnDie()
        {
            _isDead = true;
            _animator.SetBool(IsDeadKey, true);

            _creature.SetDirection(Vector2.zero);
            if (_current != null)
                StopCoroutine(_current);

        }
    }
}
