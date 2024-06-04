using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Components.Collectables
{
    [ExecuteInEditMode]
    public class RingCoins : MonoBehaviour
    {
        [SerializeField] private float _radius = 0.5f;
        [SerializeField] private bool _isCircle = true;
        [SerializeField] private float _speed = 2f;

        private float _angle = 0f;
        //private Vector3 _position;

        public void Awake()
        {

            float count = 1f;

            foreach (Transform child in transform)
            {

                var angle = 360 * Mathf.Deg2Rad;
                var rigidbodyCoin = child.GetComponent<Rigidbody2D>();

                var x = Mathf.Cos(angle / transform.childCount * count) * _radius;
                var y = Mathf.Sin(angle / transform.childCount * count) * _radius;

                child.position = (new Vector3(x, y, transform.position.z) + transform.position);

                count++;
            }

        }

        public void FixedUpdate()
        {
            float count = 1f;

            if (_isCircle)
            {
                foreach (Transform child in transform)
                {
                    var degreeAdd = 360 * Mathf.Deg2Rad / transform.childCount * count;
                    var rigidbodyCoin = child.GetComponent<Rigidbody2D>();
                    _angle += Time.deltaTime;

                    var x = Mathf.Cos((_angle * _speed) + degreeAdd) * _radius;
                    var y = Mathf.Sin((_angle * _speed) + degreeAdd) * _radius;

                    rigidbodyCoin.MovePosition(new Vector3(x , y , transform.position.z) + transform.position);
                    count++;
                }
            }
        }
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, _radius);
        }
    }
}
