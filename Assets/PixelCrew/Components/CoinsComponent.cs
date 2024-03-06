﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components
{
    public class CoinsComponent : MonoBehaviour
    {
        [SerializeField] private int _coins;
        [SerializeField] private UnityEvent _onSayCoins;
        public int Coins
        {
            get
            {
                return _coins;
            }
        }
        public void ApplyCoin(int coinValue)
        {
            _coins += coinValue;
            _onSayCoins?.Invoke();
        }
    }

}
