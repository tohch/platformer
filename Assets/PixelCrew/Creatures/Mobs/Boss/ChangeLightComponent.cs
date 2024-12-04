﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace PixelCrew.Creatures.Mobs.Boss
{
    public class ChangeLightComponent : MonoBehaviour
    {
        [SerializeField] private Light2D[] _lights;
        
        [ColorUsage(true, true)] [SerializeField] 
        private Color _color;

        [ContextMenu("Setup")]
        public void SetColor()
        {
            SetColor(_color);
        }

        public void SetColor(Color color)
        {
            foreach (var Light2D in _lights)
            {
                Light2D.color = color;
            }
        }
    }
}
