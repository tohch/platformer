﻿using PixelCrew.Model.Data.Properties;
using UnityEditor;
using UnityEngine;

namespace PixelCrew.Model.Data
{
    [CreateAssetMenu(menuName = "Data/GameSettings", fileName = "GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private FloatPersistentProperty _music;
        [SerializeField] private FloatPersistentProperty _sfx;

        public FloatPersistentProperty Music => _music;
        public FloatPersistentProperty Sfx => _sfx;

        private static GameSettings _instance;
        public static GameSettings I => _instance == null ? LoadGameSetting() : _instance;
        private static GameSettings LoadGameSetting()
        {
            return _instance = Resources.Load<GameSettings>("GameSettings");
        }
        private void OnEnable()
        {
            _music = new FloatPersistentProperty(1, SoundsSetting.Music.ToString());
            _sfx = new FloatPersistentProperty(1, SoundsSetting.Sfx.ToString());
        }

        private void OnValidate()
        {
            Music.Validate();
            Sfx.Validate();
        }
    }
    public enum SoundsSetting
    {
        Music,
        Sfx
    }
}