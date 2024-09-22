﻿using PixelCrew.Creatures.Heroes;
using PixelCrew.Model.Data;
using PixelCrew.Model.Definitions;
using PixelCrew.Model.Definitions.Repositories.Items;
using PixelCrew.Utils;
using System.Collections;
using UnityEngine;

namespace PixelCrew.Components.Collectables
{
    public class InventoryAddComponent : MonoBehaviour
    {
        [InventoryId] [SerializeField] private string _id;
        [SerializeField] private int _count;

        public void Add(GameObject go)
        {
            var hero = go.GetInterface<ICanAddInInventory>();
            hero?.AddInInventory(_id, _count);
        }
    }
}