﻿using PixelCrew.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelCrew.Model
{
    [Serializable]
    public class PlayerData
    {
        [SerializeField] private InventoryData _inventory;

        public int Coins;
        public int Hp;
        public bool IsArmed;
        public int AmountSwords;

        //public PlayerData() { }
        //public PlayerData(int coins, int hp, bool isArmed, int amountSwords)
        //{
        //    Coins = coins;
        //    Hp = hp;
        //    IsArmed = isArmed;
        //    AmountSwords = amountSwords;
        //}

        public PlayerData Clone()
        {
            var json = JsonUtility.ToJson(this);
            return JsonUtility.FromJson<PlayerData>(json);
            //return new PlayerData(Coins, Hp, IsArmed, AmountSwords);
        }

        

    }
}
