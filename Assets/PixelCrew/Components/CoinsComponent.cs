using System;
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
        [SerializeField] private UnityEvent _onSayCoins;
        [SerializeField] private Hero _hero;

        public void ApplyCoin(int coinValue)
        {
            //_hero._coins += coinValue;
            _hero.Session.Data.Coins += coinValue;
            _onSayCoins?.Invoke();
        }
    }

}
