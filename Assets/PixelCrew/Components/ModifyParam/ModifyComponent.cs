using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelCrew.Components.ModifyParam
{
    public abstract class ModifyComponent : MonoBehaviour
    {
        public abstract void Apply(GameObject target);
    }
}
