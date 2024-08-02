using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelCrew.UI.GameMenu
{
    public class GameMenu : AnimatedWindow
    {
        private Action _closeAction;

        public void OnShowSettings()
        {
            var window = Resources.Load<GameObject>("UI/SettingWindow");
            var canvas = FindObjectOfType<Canvas>();
            Instantiate(window, canvas.transform);
        }
        public void OnRestartLevel()
        {
            Scene scene = SceneManager.GetActiveScene();
            _closeAction = () => { SceneManager.LoadScene(scene.name); };
            Close();
        }
        public void OnOk()
        {
            Close();
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