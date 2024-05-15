using PixelCrew.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelCrew.Components.Collectables
{
    public class ArmHeroComponent : MonoBehaviour
    {
        [SerializeField] int _amountSwords;
        public void ArmHero(GameObject go)
        {
            var hero = go.GetComponent<Hero>();
            if (hero != null)
            {
                hero.ArmHero();
            }
        }

        public void PickupAmountSwords(GameObject go)
        {
            var hero = go.GetComponent<Hero>();
            if (hero != null)
            {
                hero.ModifyAmountSwords(_amountSwords);
            }
        }
    }
}
