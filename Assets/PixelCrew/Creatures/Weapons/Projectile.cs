﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelCrew.Creatures.Weapons
{
    class Projectile : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private int _direction;
        private Rigidbody2D _rigidbody;
        private void Start()
        {
            _direction = transform.lossyScale.x > 0 ? 1 : -1;
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            var position = _rigidbody.position;
            position.x += _direction * _speed;
            _rigidbody.MovePosition(position);
        }
    }
}
