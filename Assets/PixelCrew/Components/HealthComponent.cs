﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private UnityEvent _onDamage;
        [SerializeField] private UnityEvent _onDie;

        public void ApplyDamage(int damageValue)
        {
            _health -= damageValue;
            _onDamage?.Invoke();
            if(_health <= 0)
            {
                _onDie?.Invoke();
            }
        }
    }
}
