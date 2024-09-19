using PixelCrew.Components.Health;
using PixelCrew.Components.LevelManegement;
using PixelCrew.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components.GoBased
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _prefab;

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            var instantiate = SpawnUtils.Spawn(_prefab, _target.position);
            
            var scale = _target.lossyScale;
            instantiate.transform.localScale = scale;
            instantiate.SetActive(true);
        }

        public static void Spawn(DataForSpawnItems _dataSpawn, UnityAction<bool> SetDistroyStatus)
        {
            var health = InitSpawnAndGetHelath(_dataSpawn);

            health._onDie.AddListener(delegate { SetDistroyStatus(true); });
        }

        public static void SpawnAndDiscribeOnDie(DataForSpawnItems _dataSpawn, UnityAction<int> SetDistroyStatus, int currentItemindex)
        {
            var health = InitSpawnAndGetHelath(_dataSpawn);

            health._onDie.AddListener(delegate { SetDistroyStatus(currentItemindex); });
        }

        private static HealthComponent InitSpawnAndGetHelath(DataForSpawnItems _dataSpawn)
        {
            var instantiate = SpawnUtils.Spawn(_dataSpawn.Pregab, _dataSpawn.PositionTarget);

            var scale = _dataSpawn.PositionScale;
            instantiate.transform.localScale = scale;
            instantiate.SetActive(true);
            var health = instantiate.GetComponent<HealthComponent>();
            return health;
        }

        public void SetPrefab(GameObject prefab)
        {
            _prefab = prefab;
        }
    }
}
