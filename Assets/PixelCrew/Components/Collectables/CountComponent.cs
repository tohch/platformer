using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelCrew.Components.Collectables
{
    public class CountComponent : MonoBehaviour
    {
        [SerializeField] int _coinValue;

        public void ApplyCoin(GameObject target)
        {
            var coinsComponent = target.GetComponent<CoinsComponent>();
            if (coinsComponent != null ) 
            {
                coinsComponent.ApplyCoin(_coinValue);
            }
        }
    }
}
