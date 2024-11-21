using PixelCrew.Creatures.Weapons;
using PixelCrew.Utils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelCrew.Components.GoBased
{
    public class CircularProjectileSpawner : MonoBehaviour
    {
        [SerializeField] protected FormationProjectileSettings[] _settings;

        public int Stage { get; set; }

        [ContextMenu("Launch!")]
        public void LaunchProjectiles()
        {
            StartCoroutine(SpawnProjectiles());
        }

        protected virtual IEnumerator SpawnProjectiles()
        {
            var setting = _settings[Stage];
            var sectorAngle = 2 * Mathf.PI / setting.BurstCount;
            for (int i = 0; i < setting.BurstCount; i++)
            {
                var angle = sectorAngle * i;
                var direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

                var instance = SpawnUtils.Spawn(setting.Prefab.gameObject, transform.position);
                var projectile = instance.GetComponent<DirectionalProjectile>();
                projectile.Launch(direction);

                yield return new WaitForSeconds(setting.Delay);
            }
        }
    }

    [Serializable]
    public struct FormationProjectileSettings
    {
        [SerializeField] private DirectionalProjectile _projectile;
        [SerializeField] private int _burstCount;
        [SerializeField] private float _delay;

        public DirectionalProjectile Prefab => _projectile;
        public int BurstCount => _burstCount;
        public float Delay => _delay;
    }
}
