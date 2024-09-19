using PixelCrew.Components.GoBased;
using PixelCrew.Components.Health;
using PixelCrew.Model;
using PixelCrew.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components.LevelManegement
{
    [RequireComponent(typeof(SpawnComponent))]
    public class ItemsStatusComponent : MonoBehaviour
    {
        [SerializeField] private SpawnComponent _spawner;
        [SerializeField] private DataForSpawnItems _dataSpawn;

        public DataForSpawnItems DataForSpawn => _dataSpawn;

        private GameSession _session;
        private HealthComponent health;
        private void Awake()
        {


            _dataSpawn.PositionTarget = gameObject.transform.position;
            _dataSpawn.PositionScale = gameObject.transform.localScale;

            _session = FindObjectOfType<GameSession>();

            if (!_session.IsItemsStatusChecked())
            {
                SpawnComponent.Spawn(_dataSpawn, SetDistroyStatus);
            }
        }

        public void SetDistroyStatus(bool status)
        {
            _dataSpawn.IsDistroy = status;
        }
    }

    [Serializable]
    public class DataForSpawnItems : ICloneable
    {
        public bool IsDistroy;
        public GameObject Pregab;
        public Vector3 PositionTarget;
        public Vector3 PositionScale;

        public DataForSpawnItems(bool isDistroy, Vector3 position, Vector3 scale, GameObject pregab)
        {
            IsDistroy = isDistroy;
            PositionTarget = position;
            PositionScale = scale;
            Pregab = pregab;
        }

        public DataForSpawnItems() 
        {
        }

        public object Clone()
        {
            return new DataForSpawnItems(IsDistroy, PositionTarget, PositionScale, Pregab);
        }
    }
}