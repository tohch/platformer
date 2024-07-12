﻿using PixelCrew.Components.Audio;
using PixelCrew.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components.Health
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] private UnityEvent _onDamage;
        [SerializeField] private UnityEvent _onHeal;
        [SerializeField] private UnityEvent _onDie;
        [SerializeField] private HealthCangeEven _onChange;

        private PlaySoundsComponent _sounds;

        public int Health => _health;

        public void Awake()
        {
            _sounds = GetComponent<PlaySoundsComponent>();
        }

        public void ModifyHealth(int healthDelta)
        {
            if (_health <= 0) return;
            _health += healthDelta;
            _onChange?.Invoke(_health);

            if (healthDelta < 0)
                _onDamage?.Invoke();

            if (healthDelta > 0)
                _onHeal?.Invoke();

            if (_health <= 0)
            {
                _onDie?.Invoke();
            }
        }
        [Serializable]
        public class HealthCangeEven : UnityEvent<int>
        {
        }
#if UNITY_EDITOR
        [ContextMenu("Update Health")]
        private void UpdateHealth()
        {
            _onChange?.Invoke(_health);
        }
#endif
        internal void SetHealth(int health)
        {
            _health = health;
        }
    }
}
