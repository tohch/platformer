using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelCrew.Components.Health
{
    public class ModifyHealthComponent : MonoBehaviour
    {
        [SerializeField] private int _hpDelta;
        public void Apply(GameObject target)
        {
            var healthComponent = target.GetComponent<HealthComponent>();
            if(healthComponent != null )
            {
                healthComponent.ModifyHealth(_hpDelta);
            }
        }

        public void ChangeHpDelta(int change)
        {
            if (_hpDelta < 0)
            {
                _hpDelta = Math.Abs(change) * -1;
            }
            else
            {
                _hpDelta = Math.Abs(change);
            }
        }
    }
}
