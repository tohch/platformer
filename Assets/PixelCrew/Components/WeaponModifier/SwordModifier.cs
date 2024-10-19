using PixelCrew.Components.Health;
using PixelCrew.Model;
using PixelCrew.Model.Definitions.Player;
using System;
using System.Collections;
using UnityEngine;

namespace PixelCrew.Components.WeaponModifier
{
    [RequireComponent(typeof(ModifyHealthComponent))]

    public class SwordModifier : MonoBehaviour
    {
        private ModifyHealthComponent _modifyHealth;
        private GameSession _session;

        public void Start()
        {
            _modifyHealth = GetComponent<ModifyHealthComponent>();
            _session = FindObjectOfType<GameSession>();

            OnRangeDamageUpgraded(StatId.RangeDamage);
        }

        private void OnRangeDamageUpgraded(StatId statId)
        {
            switch (statId)
            {
                case StatId.RangeDamage:
                    var rangeDamage = (int)_session.StatsModel.GetValue(statId);
                    _modifyHealth.ChangeHpDelta(rangeDamage);
                    break;
            }
        }
    }
}