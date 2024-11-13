using PixelCrew.Utils;
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

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            SpawnInstance();
        }

        public GameObject SpawnInstance()
        {
            var instantiate = SpawnUtils.Spawn(_prefab, _target.position);

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
