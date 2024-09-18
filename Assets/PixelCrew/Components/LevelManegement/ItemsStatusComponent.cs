using PixelCrew.Components.GoBased;
using PixelCrew.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Components.LevelManegement
{
    [RequireComponent(typeof(SpawnComponent))]
    public class ItemsStatusComponent : MonoBehaviour
    {
        [SerializeField] private SpawnComponent _spawner;
        [SerializeField] private bool _isDistroy;
        [SerializeField] private Transform _target;
        private DataForSpawnItems _dataSpawn;

        private void Start()
        {
            _dataSpawn = new DataForSpawnItems(_isDistroy, GetName());
        }
        public DataForSpawnItems DataForSpawn
        {
            get
            {
                return _dataSpawn;
            }
        }

        public bool IsDistroy => _isDistroy;

        public void SpawnItem()
        {
            _spawner.Spawn();
        }

        public string GetName()
        {
            return gameObject.name;
        }
    }

    [Serializable]
    public class DataForSpawnItems : ICloneable
    {
        public bool IsDistroy;
        public string Name;

        public object Clone() => new DataForSpawnItems(IsDistroy, Name);

        public DataForSpawnItems(bool isDistroy, string name)
        {
            IsDistroy = isDistroy;
            Name = name;
        }
        public DataForSpawnItems() { }
    }
}