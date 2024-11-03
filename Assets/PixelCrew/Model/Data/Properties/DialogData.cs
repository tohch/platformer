using System;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Model.Data.Properties
{
    [Serializable]
    public struct DialogData
    {
        [SerializeField] private Sentence[] _sentences;
        [SerializeField] private DialogType _type;
        public Sentence[] Sentences => _sentences;
        public DialogType Type => _type;
    }

    [Serializable]
    public struct Sentence
    {
        [SerializeField] private string _valued;
        [SerializeField] private Sprite _icon;
        [SerializeField] private Side _side;
        [SerializeField] private UnityEvent _action;

        public string Valued => _valued;
        public Sprite Icon => _icon;
        public Side Side => _side;

        public UnityEvent Action => _action;
    }

    public enum Side
    {
        Left,
        Right
    }

    public enum DialogType
    {
        Simple,
        Personalized
    }
}