using PixelCrew.Model.Definitions.Repositories;
using PixelCrew.Model.Definitions.Repositories.Items;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PixelCrew.Model.Definitions.DefRepositories.Items
{
    [CreateAssetMenu(menuName = "Defs/Items", fileName = "Items")]
    public class ItemsRepository : DefRepository<ItemDef>
    {
#if UNITY_EDITOR
        public ItemDef[] ItemsForEditor => _collection;
#endif
    }

    [Serializable]
    public struct ItemDef : IHaveId
    {
        [SerializeField] private string _id;
        //[SerializeField] private bool _isStackable;
        [SerializeField] private Sprite _icon;
        [SerializeField] private ItemTag[] _tags;
        public string Id => _id;
        //public bool IsStackable => _isStackable;
        public bool IsVoid => string.IsNullOrEmpty(_id);

        public Sprite Icon => _icon;
        
        public bool HasTag(ItemTag tag)
        {
            return _tags.Contains(tag);
        }
    }
}