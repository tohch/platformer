using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

namespace PixelCrew
{
    public class CountCoin : MonoBehaviour
    {
        [SerializeField] private float _coinGoldValue = 10f;
        [SerializeField] private string _coinGoldName = "CoinGold";
        [SerializeField] private float _coinSilverValue = 1f;
        [SerializeField] private string _coinSilverName = "CoinSilver";
        private float coinSum;
        public void CoinSum()
        {
            if (gameObject.tag == _coinGoldName)
            {
                coinSum += _coinGoldValue;
            }
            if (gameObject.tag == _coinSilverName)
            {
                coinSum += _coinSilverValue;
            }
            Debug.Log(coinSum);
        }
    }
}

