using PixelCrew.Model;
using PixelCrew.Model.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelCrew.Components.LevelManegement
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
            session.Data = _playerData;
            //session.LoadLastSave();

            var scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
