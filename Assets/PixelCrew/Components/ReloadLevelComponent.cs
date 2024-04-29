using PixelCrew.Model;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelCrew.Components
{
    public class ReloadLevelComponent : MonoBehaviour
    {
        private PlayerData _playerData;
        private void Start()
        {
            _playerData = FindObjectOfType<GameSession>().Data.Clone();
        }
        public void Reload()
        {
            var session = FindObjectOfType<GameSession>();
            //DestroyImmediate(session);
            //Destroy(session);
            session.Data = _playerData;

            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
