using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelCrew.Utils
{
    public static class GameObjectExtensions
    {
        public static bool IsInLaver(this GameObject go, LayerMask layer)
        {
            return layer == (layer | 1 << go.layer);
        }

        public static TInterfaceType GetInterface<TInterfaceType>(this GameObject go) 
        {
            var components = go.GetComponents<Component>();
            foreach (var component in components)
            {
                if (component is TInterfaceType type)
                {
                    return type;
                }
            }

            return default;
        }
    }
}
