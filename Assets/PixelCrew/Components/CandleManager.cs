using System.Collections;
using UnityEditor;
using UnityEngine;

namespace PixelCrew.Components
{
    public class CandleManager : MonoBehaviour
    {
        [SerializeField] private GameObject _candle;
        public GameObject Candle 
        { 
            get => _candle;
            set => _candle = value; 
        }
        

        public void TurnOn(GameObject go)
        {
            var candleManager = go.GetComponent<CandleManager>();
            candleManager.Candle.SetActive(true);
        }
    }
}