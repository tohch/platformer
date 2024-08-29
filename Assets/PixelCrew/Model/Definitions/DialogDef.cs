﻿using PixelCrew.Model.Data.Properties;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrew.Model.Definitions
{
    [CreateAssetMenu(menuName = "Defs/Dialog", fileName = "Dialog")]
    public class DialogDef : ScriptableObject
    {
        [SerializeField] private DialogData _data;
        
        public DialogData Data => _data;
    }
}