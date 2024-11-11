using System.Linq;
using UnityEngine;

namespace PixelCrew.Utils
{
    public static class WindowUtils
    {
        public static void CreateWindow(string resourcePath)
        {
            var window = Resources.Load<GameObject>(resourcePath);
            //Урок
            var canvas = GameObject.FindWithTag("MainUICanvas").GetComponent<Canvas>();
            Object.Instantiate(window, canvas.transform);

            //Мой
            //var canvas = Object.FindObjectsOfType<Canvas>().Where(i => i.gameObject.layer == 5); 
            //Object.Instantiate(window, canvas.First().transform);
            //
        }
    }
}
