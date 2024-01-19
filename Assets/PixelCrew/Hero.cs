﻿using UnityEngine;

namespace PixelCrew
{
    public class Hero : MonoBehaviour
    {
        private Vector2 _direction;

        [SerializeField]
        private float _speed;
        [SerializeField]
        private float _jumpSpeed;
        [SerializeField]
        private LayerMask _groundLayer;
        [SerializeField]
        private float _groundCheckRadius;
        [SerializeField]
        private Vector3 _groundCheckPositionDelta;

        private Rigidbody2D _rigidbody;
        public void SetDirection(Vector2 direction)
        {
            _direction = direction;
        }
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }
        public void SaySomething()
        {
            Debug.Log("Say");
        }
        private bool IsGounded()
        {
            var hit = Physics2D.CircleCast(transform.position + _groundCheckPositionDelta, _groundCheckRadius, Vector2.down, 0, _groundLayer);
            return hit.collider != null;
        }
        private void OnDrawGizmos()
        {
            Gizmos.color = IsGounded() ? Color.green : Color.red;
            Gizmos.DrawSphere(transform.position + _groundCheckPositionDelta, _groundCheckRadius);
        }
        private void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(_direction.x * _speed, _rigidbody.velocity.y);
            var isJumping = _direction.y > 0;
            if (isJumping && IsGounded())
            {
                _rigidbody.AddForce(Vector2.up * _jumpSpeed, ForceMode2D.Impulse);
            }
        }
    }
}
