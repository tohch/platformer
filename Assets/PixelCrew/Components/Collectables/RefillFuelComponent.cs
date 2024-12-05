using PixelCrew.Model;
using System.Collections;
using UnityEngine;

namespace PixelCrew.Components.Collectables
{
    public class RefillFuelComponent : MonoBehaviour
    {
        public void Refill()
        {
            GameSession.Instance.Data.Fuel.Value = 100;
        }
    }
}