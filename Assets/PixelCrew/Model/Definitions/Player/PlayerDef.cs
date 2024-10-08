using PixelCrew.Model.Definitions.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

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

        public StatDef[] Stats1 => _stats;
        public StatDef GetStat(StatId id) => _stats.FirstOrDefault(x => x.ID == id);
    }
}
