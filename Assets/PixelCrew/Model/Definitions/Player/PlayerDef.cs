﻿using UnityEngine;

namespace PixelCrew.Model.Definitions.Player
{
    [CreateAssetMenu(menuName = "Defs/PlayerDef", fileName = "PlayerDef")]
    public class PlayerDef : ScriptableObject
    {
        [SerializeField] private int _invenotrySize;
        [SerializeField] private int _maxHealth;
        [SerializeField] private StatDef[] _stats;
        public int InventorySize => _invenotrySize;
        public int MaxHealth => _maxHealth;

        public StatDef[] Stats => _stats;
        public StatDef GetStat(StatId id)
        {
            foreach (var statDef in _stats)
            {
                if (statDef.ID == id)
                {
                    return statDef;
                }
            }

            return default;
        }
    }
}
