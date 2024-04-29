using PixelCrew.Creatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelCrew.Components
{
    public class CarryComponent : MonoBehaviour
    {
        [SerializeField] GameObject _barrel;
        public void SwitchCarry(GameObject target)
        {
            var hero = target.GetComponent<HeroCarryComponent>();
            if (hero != null)
            {
                hero.SwitchCarry(_barrel);
            }
        }
    }
}
