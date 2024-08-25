using PixelCrew.Components.ModifyParam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelCrew.Components.Health
{
    public class ModifyHealthComponent : ModifyComponent
    {
        [SerializeField] private int _hpDelta;
        public override void Apply(GameObject target)
        {
            var healthComponent = target.GetComponent<HealthComponent>();
            if(healthComponent != null )
            {
                healthComponent.ModifyHealth(_hpDelta);
            }
        }
    }
}
