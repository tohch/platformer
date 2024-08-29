using System;
using UnityEngine;

namespace PixelCrew.Model.Data.Properties
{
    [Serializable]
    public class DialogData
    {
        [SerializeField] private string[] _sentences;
        [SerializeField] private Sprite _avatar;
        [SerializeField] private PositionDialog _positionDialog;
        public string[] Sentences => _sentences;
        public Sprite Avatar => _avatar;
        public PositionDialog PositionDialogContainer => _positionDialog;

        public enum PositionDialog
        {
            Left,
            Right
        }

    }
}