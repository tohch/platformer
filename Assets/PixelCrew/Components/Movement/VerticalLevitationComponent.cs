using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Random = UnityEngine.Random;

namespace PixelCrew.Components.Movement
{
    public class VerticalLevitationComponent : MonoBehaviour
    {
        [SerializeField] private float _frequency = 1f;
        [SerializeField] private float _amplitude = 1f;
        [SerializeField] private bool _randomize;

        private float _originalY;
        private Rigidbody2D _rigidbody;
        private float _seed;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _originalY = _rigidbody.transform.position.y;
            if (_randomize)
            {
                _seed = Random.value * Mathf.PI * 2; ;
            }
        }
        private void Update()
        {
            var pos = _rigidbody.position;
            pos.y = (float)(_originalY + Math.Sin(_seed + Time.time * _frequency) * _amplitude);
            _rigidbody.MovePosition(pos);

        }
    }
}
