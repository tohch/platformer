﻿using PixelCrew.Utils.Disposables;
using PixelCrew.Model.Data.Properties;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrew.UI.Widgets
{
    public class AudioSettingsWidget : MonoBehaviour
    {
        [SerializeField] private Slider _slider;
        [SerializeField] private Text _value;

        private FloatPersistentProperty _model;

        private CompositeDisposable _trash = new CompositeDisposable();

        private void Start()
        {
            _trash.Retain(_slider.onValueChanged.Subscribe(OnSliderValueChanged));
        }

        public void SetModel(FloatPersistentProperty model)
        {
            _model = model;
            _trash.Retain(model.Subscribe(OnValueChanged));
            OnValueChanged(model.Value, model.Value);
        }
        private void OnSliderValueChanged(float value)
        {
            _model.Value = value;
        }

        private void OnValueChanged(float newValue, float oldValue)
        {
            var textValue = Mathf.Round(newValue * 100);
            _value.text = textValue.ToString();

            _slider.normalizedValue = newValue;
        }

        private void OnDestroy()
        {
            _trash.Dispose();
        }
    }
}