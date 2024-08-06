using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelCrew.Model.Definitions
{
    [CreateAssetMenu(menuName = "Defs/PlayerDef", fileName = "PlayerDef")]
    public class PlayerDef : ScriptableObject
    {
        [SerializeField] private int _invenotrySize;
        [SerializeField] private int _maxHealth;
        public int InventorySize => _invenotrySize;
        public int MaxHealth => _maxHealth;
    }
}
