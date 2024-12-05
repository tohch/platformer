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
        [SerializeField] private ProjctileSequence[] _settings;

        public int Stage { get; set; }

        [ContextMenu("Launch!")]
        public void LaunchProjectiles()
        {
            StartCoroutine(SpawnProjectiles());
        }

        private IEnumerator SpawnProjectiles()
        {
            var sequence = _settings[Stage];

            foreach (var setting in sequence.Sequence)
            {
                var sectorAngle = 2 * Mathf.PI / setting.BurstCount;
                for (int i = 0, burstCount = 1; i < setting.BurstCount; i++, burstCount++)
                {
                    var angle = sectorAngle * i;
                    var direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

                    var instance = SpawnUtils.Spawn(setting.Prefab.gameObject, transform.position);
                    var projectile = instance.GetComponent<DirectionalProjectile>();
                    projectile.Launch(direction);

                    if (burstCount < setting.ItemPerBurst) continue;

                    burstCount = 0;

                    yield return new WaitForSeconds(setting.Delay);
                }
            }
        }
    }

    [Serializable] 
    public struct ProjctileSequence
    {
        [SerializeField] private CircularProjectileSettings[] _sequence;

        public CircularProjectileSettings[] Sequence => _sequence;
    }

    [Serializable]
    public struct CircularProjectileSettings
    {
        [SerializeField] private DirectionalProjectile _projectile;
        [SerializeField] private int _burstCount;
        [SerializeField] private int _itemPerBurst;
        [SerializeField] private float _delay;

        public DirectionalProjectile Prefab => _projectile;
        public int BurstCount => _burstCount;
        public float Delay => _delay;

        public int ItemPerBurst => _itemPerBurst;
    }
}
