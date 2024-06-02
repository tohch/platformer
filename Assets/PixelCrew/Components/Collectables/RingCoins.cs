using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Components.Collectables
{
    public class RingCoins : MonoBehaviour
    {
        private float _angle = 0;
        private float _radius = 0.5f;
        private bool _isCircle = true;
        private float _speed = 1f;

        //private Vector3 _position;

        public void Awake()
        {

        }

        public void FixedUpdate()
        {
            if (_isCircle)
            {
                foreach (Transform child in transform)
                {
                    var rigidbodyCoin = child.GetComponent<Rigidbody2D>();
                    var _position = transform.position;

                    _angle += Time.deltaTime;

                    _position.x += Mathf.Cos((_angle * _speed) * _radius);
                    _position.y += Mathf.Sin((_angle * _speed) * _radius);
                    rigidbodyCoin.MovePosition(_position);
                }
            }
        }
    }
}
