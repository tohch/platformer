﻿using PixelCrew.UI.LevelsLoader;
using PixelCrew.Utils;
using System;
using UnityEngine;

namespace PixelCrew.UI.MainMenu
{
    public class MainMenuWindow : AnimatedWindow
    {
        private Action _closeAction;
        public void OnShowSettings()
        {
            WindowUtils.CreateWindow("UI/SettingWindow");
        }

        public void OnStartGame()
        {
            _closeAction = () => 
            {
                var loader = FindObjectOfType<LevelLoader>();
                loader.LoadLevel("Level1");
            };
            Close();
        }

        public void OnLanguages()
        {
            WindowUtils.CreateWindow("UI/LocalizationWindow");
        }

        public void OnExit()
        {
            _closeAction = () => 
            {
                Application.Quit();
#if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
#endif 
            };
            Close();
        }

        public override void OnCLoseAnimationComplete()
        {
            _closeAction?.Invoke();
            base.OnCLoseAnimationComplete();
        }
    }
}
