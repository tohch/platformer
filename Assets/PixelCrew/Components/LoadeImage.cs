using PixelCrew.Model.Definitions.Localization;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrew.Components
{
    public class LoadeImage : MonoBehaviour
    {
        [SerializeField] private string _spriteName;

        private string selectedLocale;
        private Sprite imageCurrentLocale;
        private SpriteRenderer sprite;


        private void Awake()
        {
            sprite = GetComponent<SpriteRenderer>();
            ChangeImage();

        }

        private void Start()
        {
            LocalizationManager.I.OnLocaleChanged += ChangeImage;
        }

        private void ChangeImage()
        {
            selectedLocale = LocalizationManager.I.LocaleKey;
            imageCurrentLocale = Resources.Load<Sprite>($"ImageLocales/{selectedLocale}/{_spriteName}");
            sprite.sprite = imageCurrentLocale;
        }

        private void OnDestroy()
        {
            LocalizationManager.I.OnLocaleChanged -= ChangeImage;
        }
    }
}