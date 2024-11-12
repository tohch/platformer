using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace PixelCrew.Effects.CameraRelated
{
    public class SpeakEffect : MonoBehaviour
    {
        [SerializeField] private Volume _volume;
        private Vignette _vignette;

        private float _default;

        public void Start()
        {
            _volume.profile.TryGet<Vignette>(out _vignette);
            
        }
        public void StartEffect()
        {
            _default = _vignette.intensity.value;
            _vignette.active = true;
            _vignette.intensity.value = 0.572f;
        }

        public void StotEffect()
        {
            _vignette.intensity.value = _default;
            _vignette.active = false;
        }
    }
}
