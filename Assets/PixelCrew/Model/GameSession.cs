using PixelCrew.Components.GoBased;
using PixelCrew.Components.Health;
using PixelCrew.Components.LevelManegement;
using PixelCrew.Model.Data;
using PixelCrew.Model.Data.Properties;
using PixelCrew.Utils;
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
        private DataForSpawnItems[] _itemsStatus;

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
                for (int i = 0; i < _itemsStatus.Length; i++)
                {
                    if (_itemsStatus[i].IsDistroy) continue;

                    SpawnComponent.SpawnAndDiscribeOnDie(_itemsStatus[i], SetDistroyStatus, i);
                }
            }
        }
        public void SetDistroyStatus(int i)
        {
            _itemsStatus[i].IsDistroy = true;
            var allItemSpawn = FindObjectsOfType<ItemsStatusComponent>();
            allItemSpawn[i].SetDistroyStatus(_itemsStatus[i].IsDistroy);
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
            return _itemsStatus != null;
        }

        public void SetChecked(string id)
        {
            if (!_checkpoints.Contains(id))
            {
                Save();
                _checkpoints.Add(id);
            }
        }
        public void SetItemsStatus(DataForSpawnItems[] items)
        {
            if (items != null)
            {
                Save();
                _itemsStatus = new DataForSpawnItems[items.Length];
                for (int i = 0; i < items.Length; i++)
                {
                    _itemsStatus[i] = (DataForSpawnItems)items[i].Clone();
                }
            }

        }

        public DataForSpawnItems[] GetItemsStatus()
        {
            return _itemsStatus;
        }

        private void OnDestroy()
        {
            _trash.Dispose();
        }
    }
}
