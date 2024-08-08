using PixelCrew.Components.Health;
using PixelCrew.UI.Widgets;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrew.UI.Hud
{
    public class HudMobHealthbar : MonoBehaviour
    {
        [SerializeField] private HealthComponent _mob;
        [SerializeField] private ProgressBarWidget _healthbar;

        private float _maxHp;

        private void Start()
        {
            _maxHp = (float)_mob.Health;
        }

        private void Update()
        {
            float value = _mob.Health / _maxHp;
            _healthbar.SetProgress(value);
        }
    }
}