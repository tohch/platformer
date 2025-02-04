﻿using PixelCrew.Components.Audio;
using PixelCrew.Utils;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components.Health
{
    public class HealthComponent : MonoBehaviour
    {
        [SerializeField] private int _health;
        [SerializeField] public UnityEvent _onDamage;
        [SerializeField] private UnityEvent _onHeal;
        [SerializeField] public UnityEvent _onDie;
        [SerializeField] public HealthCangeEven _onChange;
        private Lock _immune = new Lock();

        private PlaySoundsComponent _sounds;

        public int Health => _health;

        public Lock Immune => _immune;

        public void Awake()
        {
            _sounds = GetComponent<PlaySoundsComponent>();
        }

        public void ModifyHealth(int healthDelta)
        {
            if (healthDelta < 0 && Immune.IsLocked) return;

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

        private void OnDestroy()
        {
            _onDie.RemoveAllListeners();
        }
    }
}
