﻿using PixelCrew.Components.Health;
using PixelCrew.Utils;
using System.Collections;
using UnityEngine;

namespace PixelCrew.Components
{
    public class HeroShield : MonoBehaviour
    {
        [SerializeField] private HealthComponent _health;
        [SerializeField] private Cooldown _cooldown;

        public void Use()
        {
            _health.Immune = true;
            _cooldown.Reset();
            gameObject.SetActive(true);
        }

        private void Update()
        {
            if (_cooldown.IsReady)
                gameObject.SetActive(false);
        }

        private void OnDisable()
        {
            _health.Immune = false;
        }
    }
}