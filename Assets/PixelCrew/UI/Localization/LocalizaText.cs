﻿using PixelCrew.Model.Definitions.Localization;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrew.UI.Localization
{
    [RequireComponent(typeof(Text))]
    public class LocalizaText : MonoBehaviour
    {
        [SerializeField] private string _key;
        [SerializeField] private bool _capitalize;

        private Text _text;

        public void Awake()
        {
            _text = GetComponent<Text>();

            LocalizationManager.I.OnLocaleChanged += OnLocaleChanged;
            Localize();
        }

        private void OnLocaleChanged()
        {
            Localize();
        }

        private void Localize()
        {
            var localized = LocalizationManager.I.Localize(_key);
            _text.text = _capitalize ? localized.ToUpper() : localized;
        }
    }
}