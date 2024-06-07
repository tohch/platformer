using PixelCrew.Creatures;
using PixelCrew.Creatures.Heroes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components.Collectables
{
    public class CoinsComponent : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onSayCoins;
        private Hero _hero;
        public void Start()
        {
            _hero = gameObject.GetComponent<Hero>();
        }
        public void ApplyCoin(int coinValue)
        {
            _hero.Session.Data.Inventory.Add("Coin", coinValue);
            //_hero.Session.Data.Coins += coinValue;
            _onSayCoins?.Invoke();
        }
    }

}
