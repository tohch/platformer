using PixelCrew.Model.Data;
using PixelCrew.UI.Widgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelCrew.UI.Settings
{
    public class SettingWindow : AnimatedWindow
    {
        [SerializeField] private AudioSettingsWidget _music; 
        [SerializeField] private AudioSettingsWidget _sfx; 
        protected override void Start()
        {
            base.Start();

            _music.SetModel(GameSettings.I.Music);
            _sfx.SetModel(GameSettings.I.Sfx);
        }
    }
}
