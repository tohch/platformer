using UnityEditor;
using UnityEngine;

namespace PixelCrew.Components.Collectables
{
    public class RingCoin : MonoBehaviour
    {
        private float angle = 0f;
        private float _originalY;
        private float _originalX;
        private Rigidbody2D rigidbodyCoin;
        public void Start()
        {
            rigidbodyCoin = gameObject.GetComponent<Rigidbody2D>();
            _originalX = rigidbodyCoin.position.x;
            _originalY = rigidbodyCoin.position.y;
        }
        public void Rotate(float speed, float radius, Vector2 center)
        {
            var position = rigidbodyCoin.position;

            position.x = center.x + Mathf.Cos(angle * speed) * radius;
            position.y = center.y + Mathf.Sin(angle * speed) * radius;

            rigidbodyCoin.MovePosition(position);
            angle += Time.fixedDeltaTime;
        }
    }
}