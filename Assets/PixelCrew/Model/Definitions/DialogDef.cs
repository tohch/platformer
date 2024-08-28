using PixelCrew.Model.Data.Properties;
using System.Collections;
using UnityEngine;

namespace PixelCrew.Model.Definitions
{
    public class DialogDef : ScriptableObject
    {
        [SerializeField] private DialogData _data;
        public DialogData Data => _data;
    }
}