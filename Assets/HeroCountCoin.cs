using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroCountCoin : MonoBehaviour
{
    //add
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
    //add
}
