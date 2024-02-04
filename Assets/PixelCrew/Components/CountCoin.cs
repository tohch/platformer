using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

namespace PixelCrew
{
    public class CountCoin : MonoBehaviour
    {
        [SerializeField] private HeroCountCoin _hero;

        public void CoinCount()
        {
            _hero.CoinSum(gameObject.tag);
        }
    }
}

