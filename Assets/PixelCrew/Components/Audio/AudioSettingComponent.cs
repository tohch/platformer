﻿using PixelCrew.Model.Data;
using PixelCrew.Model.Data.Properties;
using System;
using System.Collections;
using UnityEngine;

namespace PixelCrew.Components.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioSettingComponent : MonoBehaviour
    {
        [SerializeField] private SoundsSetting _mode;
        private AudioSource _source;
        private FloatPersistentProperty _model;

        private void Start()
        {
            _source = GetComponent<AudioSource>();

            _model = FindProperty();
            _model.OnChanged += OnSoundSettingChanged;
            OnSoundSettingChanged(_model.Value, _model.Value);
        }

        private void OnSoundSettingChanged(float newValue, float oldValue)
        {
            _source.volume = newValue;
        }

        private FloatPersistentProperty FindProperty()
        {
            switch (_mode)
            {
                case SoundsSetting.Music:
                    return GameSettings.I.Music;
                case SoundsSetting.Sfx:
                    return GameSettings.I.Sfx;
            }
            throw new ArgumentException("Undefined mode");
        }

        private void OnDestroy()
        {
            // my checking of null
            if (_model != null)
                _model.OnChanged -= OnSoundSettingChanged;
        }
    }
}