using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HeroCountCoin : MonoBehaviour
{
    [SerializeField] private float _coinGoldValue;
    [SerializeField] private string _coinGoldName;
    [SerializeField] private float _coinSilverValue;
    [SerializeField] private string _coinSilverName;

    private float coinSum;
    public void CoinSum(string tag)
    {
        if (tag == _coinGoldName)
        {
            coinSum += _coinGoldValue;
        }
        if (tag == _coinSilverName)
        {
            coinSum += _coinSilverValue;
        }
        Debug.Log(coinSum);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.CompareTag(_coinGoldName) || other.gameObject.CompareTag(_coinSilverName))
            {
                CoinSum(other.gameObject.tag);
            }
    }

}
