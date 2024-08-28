using PixelCrew.Model.Data.Properties;
using PixelCrew.Model.Definitions;
using System.Collections;
using UnityEngine;

namespace PixelCrew.Components.Dialogs
{
    [CreateAssetMenu(menuName = "Defs/Dialog", fileName = "Dialog")]
    public class ShowDialogComponent : MonoBehaviour
    {
        [SerializeField] private Mode _mode;
        [SerializeField] private DialogData _bound;
        [SerializeField] private DialogDef _external;

        public enum Mode
        {
            Bound,
            External
        }
    }
}