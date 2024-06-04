using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Components.Collectables
{
    public class RingCoins : MonoBehaviour
    {
        [SerializeField] private float _radius = 0.5f;
        [SerializeField] private bool _isCircle = true;
        [SerializeField] private float _speed = 2f;

        private float _angle = 0f;
        //private Vector3 _position;

        private float _k;
        public void Awake()
        {
            _k = (Mathf.Sin(360/transform.childCount))/2;
            float count = 1f;
            float index = 0f;
            var _position = transform.position;
            foreach (Transform child in transform)
            {

                _angle = 360 * Mathf.Deg2Rad;
                index += (Mathf.PI * _radius * (360 / transform.childCount)) / 180;
                var rigidbodyCoin = child.GetComponent<Rigidbody2D>();
                //_angle += Time.deltaTime;

                //var x = Mathf.Cos(_angle * _speed + index) ;
                var x = Mathf.Cos(_angle / transform.childCount * count) * _radius;
                //var y = Mathf.Sin(_angle * _speed + index) ;
                var y = Mathf.Sin(_angle / transform.childCount * count) * _radius;



                child.position = (new Vector3(x, y, transform.position.z) + transform.position);
                //index += 360/(_radius * 2 * _k);
                //надо получить 1.57
                count++;
            }

        }

        public void FixedUpdate()
        {
            float index = 0f;
            float count = 1f;
            var _position = transform.position;
            if (_isCircle)
            {
                foreach (Transform child in transform)
                {

                    index += (Mathf.PI * _radius * (360 / transform.childCount)) / 180;
                    var rigidbodyCoin = child.GetComponent<Rigidbody2D>();
                    _angle += Time.deltaTime;
                    //_angle = 360 * Mathf.Deg2Rad;

                    var x = Mathf.Cos((_angle * _speed) + (360 * Mathf.Deg2Rad / transform.childCount * count)) * _radius;
                    //var x = Mathf.Cos(_angle * _speed) * _radius + Mathf.Cos(_angle / transform.childCount * count) * _radius; ;
                    //var x = Mathf.Cos((_angle / transform.childCount * count) * _speed) * _radius;
                    var y = Mathf.Sin((_angle * _speed) + (360 * Mathf.Deg2Rad / transform.childCount * count)) * _radius;
                    //var y = Mathf.Sin((_angle / transform.childCount * count) * _speed) * _radius;
                    //var y = Mathf.Sin(_angle * _speed) * _radius + Mathf.Sin(_angle / transform.childCount * count) * _radius; ;



                    rigidbodyCoin.MovePosition(new Vector3(x , y , transform.position.z) + transform.position);
                    //index += 360/(_radius * 2 * _k);
                    //надо получить 1.57
                    count++;
                }
            }
        }
    }
}
