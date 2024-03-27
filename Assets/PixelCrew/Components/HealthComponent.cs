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
        [SerializeField] private UnityEvent _onHeal;
        [SerializeField] private UnityEvent _onDie;

        public int Health => _health;

        public void ModifyHealth(int healthDelta)
        {
            _health += healthDelta;
            
            if (healthDelta < 0)
                _onDamage?.Invoke();

            if (healthDelta > 0)
                _onHeal?.Invoke();

            if (_health <= 0)
            {
                _onDie?.Invoke();
            }
        }
    }
}
