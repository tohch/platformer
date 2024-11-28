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
        [SerializeField] private CircularProjectileSettings[] _settings;

        public int Stage { get; set; }

        private CircularProjectileSettings _setting;
        private float _sectorAngle;

        [ContextMenu("Launch!")]
        public void LaunchProjectiles()
        {
            StartCoroutine(SpawnProjectiles());
        }

        private IEnumerator SpawnProjectiles()
        {
            _setting = _settings[Stage];
            _sectorAngle = 2 * Mathf.PI / _setting.BurstCount;
            for (int i = 0; i < _setting.BurstCount; i++)
            {
                float summR = 0;
                for (int j = 0; j < _setting.CountPerBurst; j++)
                {
                    summR += _setting.DeltaRPErBurst;
                    ProjectileInstanceLaunch(i, summR);
                }
                    yield return new WaitForSeconds(_setting.Delay);
            }
        }

        private void ProjectileInstanceLaunch(int count, float r)
        {
            count++;
            
            var x = Mathf.Cos((360 * Mathf.Deg2Rad) / _setting.BurstCount * count) * r;
            var y = Mathf.Sin((360 * Mathf.Deg2Rad) / _setting.BurstCount * count) * r;
            var postitionInstance = (new Vector3(x, y, transform.position.z) + transform.position);
            
            var instance = SpawnUtils.Spawn(_setting.Prefab.gameObject, postitionInstance);
            var projectile = instance.GetComponent<DirectionalProjectile>();
            
            var angle = _sectorAngle * count;
            var direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
            projectile.Launch(direction);
        }
    }


    [Serializable]
    public struct CircularProjectileSettings
    {
        [SerializeField] private DirectionalProjectile _projectile;
        [SerializeField] private int _burstCount;
        [SerializeField] private int _countPerBurst;
        [SerializeField] private float _deltaRPerBurst;
        [SerializeField] private float _delay;

        public DirectionalProjectile Prefab => _projectile;
        public int BurstCount => _burstCount;
        public int CountPerBurst => _countPerBurst;
        public float DeltaRPErBurst => _deltaRPerBurst;
        public float Delay => _delay;
    }
}
