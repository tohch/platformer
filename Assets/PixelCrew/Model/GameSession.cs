using PixelCrew.Model.Data;
using PixelCrew.Model.Data.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelCrew.Model
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private PlayerData _data;

        public QuickInventoryModel QuickInventory { get; private set; }

        public PlayerData Data 
        {
            get => _data;
            set => _data = value;
        }

        private void Awake()
        {
            LoadHud();

            if (IsSessionExit())
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                //Save();
                InitModels();
                DontDestroyOnLoad(this);
            }
        }

        private void InitModels()
        {
            QuickInventory = new QuickInventoryModel(Data);
        }

        private void LoadHud()
        {
            SceneManager.LoadScene("Hud", LoadSceneMode.Additive);
        }

        private bool IsSessionExit()
        {
            var sessions = FindObjectsOfType<GameSession>();
            foreach(var gameSession in sessions)
            {
                if (gameSession != this)
                    return true;
            }
            return false;
        }

        //public void Save()
        //{
        //    _save = _data.Clone();
        //}
        //public void LoadLastSave()
        //{
        //    _data = _save.Clone();
        //}
    }
}
