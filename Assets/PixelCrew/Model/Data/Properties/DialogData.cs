using System;
using UnityEngine;

namespace PixelCrew.Model.Data.Properties
{
    [Serializable]
    public class DialogData
    {
        [SerializeField] private string[] _sentences;
        public string[] Sentences => _sentences;
    }
}