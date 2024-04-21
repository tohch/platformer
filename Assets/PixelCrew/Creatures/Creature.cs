﻿using PixelCrew.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelCrew.Creatures
{
    public class Creature : MonoBehaviour
    {
        [Header("Params")]
        [SerializeField] private float _speed;
        [SerializeField] protected float _jumpSpeed;
        [SerializeField] protected float _damageVelocity;
        [SerializeField] private int _damage;

        [Header("Checkers")]
        [SerializeField] protected LayerMask _groundLayer;
        [SerializeField] private LayerCheck _groundCheck;
        [SerializeField] private CheckCircleOverlap _attackRange;
        [SerializeField] protected SpawnListComponent _particles;

        protected Rigidbody2D _rigidbody;
        protected Vector2 Direction;
        protected Animator Animator;
        protected bool IsGrounded;
        private bool _isJumping;
        private bool _isTakeDamage = false;

        private static readonly int IsGroundKey = Animator.StringToHash("is-ground");
        private static readonly int IsRunning = Animator.StringToHash("is-running");
        private static readonly int VerticalVelocity = Animator.StringToHash("vertical-velocity");
        private static readonly int Hit = Animator.StringToHash("hit");
        private static readonly int AttackKey = Animator.StringToHash("attack");

        protected virtual void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            Animator = GetComponent<Animator>();
        }

        public void SetDirection(Vector2 direction)
        {
            Direction = direction;
        }

        protected virtual void Update()
        {
            IsGrounded = _groundCheck.IsTouchingLayer;
        }
        protected virtual void FixedUpdate()
        {
            var xVelocity = Direction.x * _speed;
            var yVelocity = CalculateYVelocity();
            _rigidbody.velocity = new Vector2(xVelocity, yVelocity);
            Animator.SetBool(IsGroundKey, IsGrounded);
            Animator.SetFloat(VerticalVelocity, _rigidbody.velocity.y);
            Animator.SetBool(IsRunning, Direction.x != 0);
            UpdateSpriteDirection();
        }

        protected virtual float CalculateYVelocity()
        {
            var yVelocity = _rigidbody.velocity.y;
            var isJumpPressing = Direction.y > 0;

            if (IsGrounded) 
            {
                _isJumping = false;
            } 
            
            if (isJumpPressing)
            {
                _isJumping = true;

                var isFalling = _rigidbody.velocity.y <= 0.001f;
                yVelocity = isFalling ? CalculateJumpVelocity(yVelocity) : yVelocity;
            }
            else if (_rigidbody.velocity.y > 0 && !_isTakeDamage && _isJumping)
            {
                yVelocity *= 0.5f;
            }
            return yVelocity;
        }

        protected virtual float CalculateJumpVelocity(float yVelocity)
        {

            if (IsGrounded)
            {
                yVelocity += _jumpSpeed;
                _particles.Spawn("Jump");
            }

            return yVelocity;
        }

        private void UpdateSpriteDirection()
        {
            if (Direction.x > 0)
            {
                transform.localScale = Vector3.one;
            }
            else if (Direction.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }

        public virtual void TakeDamage()
        {
            _isJumping = false;//? is in video
            Animator.SetTrigger(Hit);
            var isJumpPressing = Direction.y > 0;
            if (!isJumpPressing)
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, _damageVelocity);
        }
        public void OnTakeDamageFlag()
        {
            _isTakeDamage = true;
        }
        public void OffTakeDamageFlag()
        {
            _isTakeDamage = false;
        }

        public virtual void Attack()
        {
            Animator.SetTrigger(AttackKey);
        }

        public void OnDoAttack()
        {
            _attackRange.Check();
            //var gos = _attackRange.GetObjectsInRange();
            //foreach (var go in gos)
            //{
            //    var hp = go.GetComponent<HealthComponent>();
            //    if (hp != null && go.CompareTag("Enemy"))
            //    {
            //        if (hp.Health > 0)
            //            hp.ModifyHealth(-_damage);
            //    }
            //}
        }
    }
}
