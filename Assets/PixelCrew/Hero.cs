using UnityEngine;

namespace PixelCrew
{
    public class Hero : MonoBehaviour
    {
        private Vector2 _direction;

        [SerializeField] private float _speed;
        [SerializeField] private float _jumpSpeed;

        [SerializeField] private LayerCheck _groundCheck;

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
            return _groundCheck.IsTouchingLayer;
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
