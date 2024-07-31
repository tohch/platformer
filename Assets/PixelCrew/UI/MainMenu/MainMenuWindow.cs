using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelCrew.UI.MainMenu
{
    public class MainMenuWindow : AnimatedWindow
    {
        private Action _closeAction;
        public void OnShowSettings()
        {
            var window = Resources.Load<GameObject>("UI/SettingWindow");
            var canvas = FindObjectOfType<Canvas>();
            Instantiate(window, canvas.transform);
        }

        public void OnStartGame()
        {
            _closeAction = () => {SceneManager.LoadScene("Level1");};
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
            base.OnCLoseAnimationComplete();
            _closeAction?.Invoke();
           
        }
    }
}
