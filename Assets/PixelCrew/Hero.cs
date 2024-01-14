using UnityEngine;

namespace PixelCrew
{
    public class Hero : MonoBehaviour
    {
        private Vector2 _direction;

        [SerializeField]
        private float _speed;
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

        private void FixedUpdate()
        {
            _rigidbody.velocity = new Vector2(_direction.x * _speed, _rigidbody.velocity.y);
        }
    }
}
