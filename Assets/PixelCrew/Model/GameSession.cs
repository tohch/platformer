﻿using PixelCrew.Components.LevelManegement;
using PixelCrew.Model.Data;
using PixelCrew.Model.Data.Properties;
using PixelCrew.Utils.Disposables;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelCrew.Model
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private PlayerData _data;
        [SerializeField] private string _defaultCkeckPoint;

        public PlayerData Data => _data;
        private PlayerData _save;

        private readonly CompositeDisposable _trash = new CompositeDisposable();

        public QuickInventoryModel QuickInventory { get; private set; }

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
                StartSession(_defaultCkeckPoint);
            }
        }

        private void StartSession(string _defaultCkeckPoint)
        {
            SetChecked(_defaultCkeckPoint);
            LoadHud();
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
        }

        private void LoadHud()
        {
            SceneManager.LoadScene("Hud", LoadSceneMode.Additive);
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
            _trash.Dispose();
        }
    }
}
