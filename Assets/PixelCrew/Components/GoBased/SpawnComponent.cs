using PixelCrew.Utils;
using PixelCrew.Utils.ObjectPool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelCrew.Components.GoBased
{
    public class SpawnComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private GameObject _prefab;
        [SerializeField] private bool _usePool;

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            SpawnInstance();
        }

        public GameObject SpawnInstance()
        {
            var targetPosition = _target.position;

            var instantiate = _usePool
                ? Pool.Instance.Get(_prefab, targetPosition)
                : SpawnUtils.Spawn(_prefab, targetPosition);

            var scale = _target.lossyScale;
            instantiate.transform.localScale = scale;
            instantiate.SetActive(true);
            return instantiate;
        }

        public void SetPrefab(GameObject prefab)
        {
            _prefab = prefab;
        }
    }
}
