﻿using PixelCrew.Components.LevelManegement;
using PixelCrew.Model.Data;
using PixelCrew.Model.Data.Properties;
using PixelCrew.Model.Definitions.Player;
using PixelCrew.Model.Models;
using PixelCrew.Utils.Disposables;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

namespace PixelCrew.Model
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private PlayerData _data;
        [SerializeField] private string _defaultCkeckPoint;

        public static GameSession Instance { get; private set; }

        public PlayerData Data => _data;
        private PlayerData _save;

        private readonly CompositeDisposable _trash = new CompositeDisposable();

        public QuickInventoryModel QuickInventory { get; private set; }
        public PerksModel PerksModel { get; private set; }
        public StatsModel StatsModel { get; private set; }

        private readonly List<string> _checkpoints = new List<string>();

        private void Awake()
        {
            var existSession = GetExistSession();
            if (existSession != null)
            {
                existSession.StartSession(_defaultCkeckPoint);
                Destroy(gameObject);
            }
            else
            {
                Save();
                InitModels();
                DontDestroyOnLoad(this);
                Instance = this;
                StartSession(_defaultCkeckPoint);
            }
        }

        private void StartSession(string _defaultCkeckPoint)
        {
            SetChecked(_defaultCkeckPoint);
            LoadUIs();
            SpawnHero();
        }

        private void SpawnHero()
        {
            var checkpoints = FindObjectsOfType<CheckPointComponent>();
            var lastCheckPoint = _checkpoints.Last();
            foreach (var checkPoint in checkpoints)
            {
                if (checkPoint.Id == lastCheckPoint)
                {
                    checkPoint.SpawnHero();
                    break;
                }
            }
        }

        private void InitModels()
        {
            QuickInventory = new QuickInventoryModel(_data);
            _trash.Retain(QuickInventory);

            PerksModel = new PerksModel(_data);
            _trash.Retain(PerksModel);

            StatsModel = new StatsModel(_data);
            _trash.Retain(StatsModel);

            _data.Hp.Value = (int) StatsModel.GetValue(StatId.Hp);
        }

        private void LoadUIs()
        {
            SceneManager.LoadScene("Hud", LoadSceneMode.Additive);
            LoadOnScreenControls();
        }

        [Conditional("USE_ONSCREEN_CONTROLS")]
        private void LoadOnScreenControls()
        {
            SceneManager.LoadScene("Controls", LoadSceneMode.Additive);
        }

        private GameSession GetExistSession()
        {
            var sessions = FindObjectsOfType<GameSession>();
            foreach(var gameSession in sessions)
            {
                if (gameSession != this)
                    return gameSession;
            }
            return null;
        }

        public void Save()
        {
            _save = _data.Clone();
        }

        public void LoadLastSave()
        {
            _data = _save.Clone();

            _trash.Dispose();
            InitModels();
        }

        public bool IsChecked(string id)
        {
            return _checkpoints.Contains(id);
        }

        public void SetChecked(string id)
        {
            if (!_checkpoints.Contains(id))
            {
                Save();
                _checkpoints.Add(id);
            }
        }

        private void OnDestroy()
        {
            if (Instance == this)
                Instance = null;
            _trash.Dispose();
        }

        private readonly List<string> _removedItems = new List<string>();

        public bool RestoreState(string itemId)
        {
            return _removedItems.Contains(itemId);
        }

        public void StoreState(string itemId)
        {
            if (!_removedItems.Contains(itemId))
            _removedItems.Add(itemId);
        }
    }
}
