using System.Collections;
using UnityEngine;

namespace PixelCrew.UI.GameMenu
{
    public class ShowerGameMenu : MonoBehaviour
    {
        public void OnShowGameMenu()
        {
            var windowInScen = GameObject.Find("GameMenuWindow(Clone)");
            if (windowInScen == null)
            {
                var window = Resources.Load<GameObject>("UI/GameMenuWindow");
                var canvas = FindObjectOfType<Canvas>();
                Instantiate(window, canvas.transform);
            }
        }    

    }
}