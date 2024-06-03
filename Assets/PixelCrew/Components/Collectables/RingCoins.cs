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

        private float _angle = 0;
        //private Vector3 _position;

        private float _k;
        public void Awake()
        {
            _k = (Mathf.Sin(360/transform.childCount))/2;   
        }

        public void FixedUpdate()
        {
            float index = 0f;
            var _position = transform.position;
            if (_isCircle)
            {
                foreach (Transform child in transform)
                {

                    index += (Mathf.PI * _radius * (360 / transform.childCount)) / 180;
                    var rigidbodyCoin = child.GetComponent<Rigidbody2D>();
                    //_angle += Time.deltaTime;
                    _angle += Time.deltaTime;

                    //var x = Mathf.Cos(_angle * _speed + index) ;
                    var x = Mathf.Cos(_angle * _speed + index) * _radius;
                    //var y = Mathf.Sin(_angle * _speed + index) ;
                    var y = Mathf.Sin(_angle * _speed + index) * _radius;


                    
                    rigidbodyCoin.MovePosition(new Vector3(x , y , transform.position.z) + transform.position);
                    //index += 360/(_radius * 2 * _k);
                    //надо получить 1.57
                }
            }
        }
    }
}
