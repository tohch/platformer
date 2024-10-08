using PixelCrew.Model.Definitions.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelCrew.Model.Definitions.Player
{
    [Serializable]
    public struct StatDef
    {
        [SerializeField] private StatId _id;
        [SerializeField] private string _name;
        [SerializeField] private Sprite _icon;
        [SerializeField] private StatLevel[] _levels;

        public StatId ID => _id;
        public string Name => _name;
        public Sprite Icon => _icon;
        public StatLevel[] Levels => _levels;
    }

    [Serializable]
    public struct StatLevel
    {
        [SerializeField] private float _value;
        [SerializeField] private ItemWithCount _price;

        public float Value => _value;
        public ItemWithCount Price => _price;
    }

    public enum StatId
    {
        Hp,
        Speed,
        RangeDamage
    }
}
