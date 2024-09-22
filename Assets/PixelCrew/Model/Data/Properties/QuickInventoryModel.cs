using PixelCrew.Model.Definitions;
using PixelCrew.Model.Definitions.Repositories.Items;
using PixelCrew.Utils.Disposables;
using System;
using UnityEngine;

namespace PixelCrew.Model.Data.Properties
{
    public class QuickInventoryModel : IDisposable
    {
        private PlayerData _data;

        public InventoryItemData[] Inventory { get; private set; }

        public readonly IntProperty SelectedIndex = new IntProperty();

        public event Action Onchanged;

        public InventoryItemData SelectedItem => Inventory[SelectedIndex.Value];

        public QuickInventoryModel(PlayerData data)
        {
            _data = data;

            Inventory = _data.Inventory.GetAll(ItemTag.Usable);
            _data.Inventory.OnChanged += OnChangedInventory;
        }

        public IDisposable Subscribe(Action call)
        {
            Onchanged += call;
            return new ActionDisposable(() => Onchanged -= call);
        }

        private void OnChangedInventory(string id, int value)
        {
            Inventory = _data.Inventory.GetAll(ItemTag.Usable);
            SelectedIndex.Value = Mathf.Clamp(SelectedIndex.Value, 0, Inventory.Length - 1);
            Onchanged?.Invoke();
        }

        public void SetNextItem()
        {
            SelectedIndex.Value = (int)Mathf.Repeat(SelectedIndex.Value + 1, Inventory.Length);
        }

        public void Dispose()
        {
            _data.Inventory.OnChanged -= OnChangedInventory;
        }
    }
}