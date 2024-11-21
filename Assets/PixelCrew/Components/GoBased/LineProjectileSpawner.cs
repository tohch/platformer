using PixelCrew.Creatures.Weapons;
using PixelCrew.Utils;
using System;
using System.Collections;
using UnityEngine;

namespace PixelCrew.Components.GoBased
{
    public class LineProjectileSpawner : CircularProjectileSpawner
    {
        [SerializeField] private SpawnDeltaPosition _spawnDelta;
        protected override IEnumerator SpawnProjectiles()
        {
            var setting = _settings[Stage];
            var spawnPosition = transform.position;
            spawnPosition.x += _spawnDelta.X; 
            spawnPosition.y += _spawnDelta.Y; 

            for (int i = 0; i < setting.BurstCount; i++)
            {
                var direction = new Vector2(Vector2.zero.x, Vector2.down.y);
                spawnPosition.x += _spawnDelta.DistanceX;

                var instance = SpawnUtils.Spawn(setting.Prefab.gameObject, spawnPosition);
                var projectile = instance.GetComponent<DirectionalProjectile>();
                projectile.Launch(direction);

                yield return new WaitForSeconds(setting.Delay);
            }

        }

        [Serializable]
        public struct SpawnDeltaPosition
        {
            [SerializeField] private float _x;
            [SerializeField] private float _y;
            [SerializeField] private float _distanceX;

            public float X => _x;
            public float Y => _y;
            public float DistanceX => _distanceX;
        }
    }
}