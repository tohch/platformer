using PixelCrew.Model.Definitions;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Model.Data
{
    [Serializable]
    public class InventoryData
    {
        [SerializeField] private List<InventoryItemData> _inventory = new List<InventoryItemData>();

        public delegate void OnInvenotryChanged(GameObject sender,string id, int value);

        public OnInvenotryChanged OnChanged;

        public void Add(GameObject sender, string id, int value)
        {
            if (value <= 0) return;

            var itemDef = DefsFacade.I.Items.Get(id);
            if (itemDef.IsVoid) return;

            var item = GetItem(id);
            if(item == null)
            {
                item = new InventoryItemData(id);
                _inventory.Add(item);
                
            }
            item.Value += value;

            OnChanged?.Invoke(sender, id, Count(id));

        }

        public void Remove(GameObject sender, string id, int value)
        {
            var itemDef = DefsFacade.I.Items.Get(id);
            if (itemDef.IsVoid) return;

            var item = GetItem(id);
            if (item == null) return;

            item.Value -= value;

            if(item.Value <= 0)
                _inventory.Remove(item);

            OnChanged?.Invoke(sender, id, Count(id));
        }

        private InventoryItemData GetItem(string id)
        {
            foreach(var itemData in _inventory)
            {
                if (itemData.Id == id)
                    return itemData;
            }

            return null;
        }

        public int Count(string id)
        {
            var count = 0;
            foreach(var item in _inventory)
            {
                if (item.Id == id)
                    count += item.Value;
            }
            return count;
        }
    }

    [Serializable]
    public class InventoryItemData
    {
        public string Id;
        public int Value;

        public InventoryItemData(string id)
        {
            Id = id;
        }
    }
}