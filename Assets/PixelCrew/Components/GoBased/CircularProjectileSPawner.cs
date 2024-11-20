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
        [SerializeField] private DirectionalProjectile _projectile;
        [SerializeField] private int _burstCount;
        [SerializeField] private float _delay;

        [ContextMenu("Launch!")]
        public void LaunchProjectiles()
        {
            StartCoroutine(SpawnProjectiles());
        }

        private IEnumerator SpawnProjectiles()
        {
            var sectorAngle = 2 * Mathf.PI / _burstCount;
            for (int i = 0; i < _burstCount; i++)
            {
                var angle = sectorAngle * i;
                var direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

                var instance = SpawnUtils.Spawn(_projectile.gameObject, transform.position);
                var projectile = instance.GetComponent<DirectionalProjectile>();
                projectile.Launch(direction);

                yield return new WaitForSeconds(_delay);
            }
        }
    }
}
