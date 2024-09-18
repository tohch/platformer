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
        private List<DataForSpawnItems> _itemsStatus = new List<DataForSpawnItems>();

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
            LoadItemsStatus();
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

        private void LoadItemsStatus()
        {
            if (IsItemsStatusChecked())
            {
                var items = FindObjectsOfType<ItemsStatusComponent>();
                for (int i = 0; i < items.Length; i++)
                {
                    //if (items[i].DataForSpawn.Name != _itemsStatus[i].Name) continue;

                    items[i].DataForSpawn.IsDistroy = _itemsStatus[i].IsDistroy;

                    if (!items[i].IsDistroy)
                        items[i].SpawnItem();
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

        public bool IsItemsStatusChecked()
        {
            return _itemsStatus.Count > 0;
        }

        public void SetChecked(string id)
        {
            if (!_checkpoints.Contains(id))
            {
                Save();
                _checkpoints.Add(id);
            }
        }
        public void SetItemsStatus(List<ItemsStatusComponent> items)
        {
            if (items != null)
            {
                Save();
                foreach (var item in items)
                {
                    _itemsStatus.Add((DataForSpawnItems)item.DataForSpawn.Clone());
                }
            }

        }

        public List<DataForSpawnItems> GetItemsStatus()
        {
            return _itemsStatus;
        }

        private void OnDestroy()
        {
            _trash.Dispose();
        }
    }
}
