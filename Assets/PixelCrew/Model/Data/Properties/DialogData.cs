using System;
using UnityEngine;

namespace PixelCrew.Model.Data.Properties
{
    [Serializable]
    public class DialogData
    {
        [SerializeField] private Sentence[] _sentences;

        public Sentence[] Sentences => _sentences;

        public enum PositionDialog
        {
            Left,
            Right
        }

        [Serializable] 
        public class Sentence
        {
            public string SentenceText;
            public Sprite Avatar;
            public PositionDialog PositionDialog;
        }
    }
}