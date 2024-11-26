using PixelCrew.Creatures.Weapons;
using PixelCrew.Utils;
using System;
using System.Collections;
using UnityEngine;

namespace PixelCrew.Components.GoBased
{
    public class LineProjectileSpawner : MonoBehaviour
    {
        [SerializeField] private LineProjectileSettings _settings;

        public int BurstCount => _settings.BurstCount;
        public void LaunchProjectiles()
        {
            var spawnPosition = _settings.Transform.position;

            SpawnUtils.Spawn(_settings.Prefab.gameObject, spawnPosition);
            spawnPosition.x += _settings.DistanceBetvine;

        }
    }

    [Serializable]
    public struct LineProjectileSettings
    {
        [SerializeField] private GameObject _projectile;
        [SerializeField] private Transform _transform;
        [SerializeField] private float _distanceBetvine;
        [SerializeField] private int _burstCount;
        [SerializeField] private float _delay;

        public GameObject Prefab => _projectile;
        public int BurstCount => _burstCount;
        public Transform Transform => _transform;
        public float DistanceBetvine => _distanceBetvine;
    }
}