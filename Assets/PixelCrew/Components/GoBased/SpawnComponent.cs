﻿using System;
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
        //[SerializeField] private bool _invertXScale;

        [ContextMenu("Spawn")]
        public void Spawn()
        {
            var instantiate = Instantiate(_prefab, _target.position, Quaternion.identity);
            
            var scale = _target.lossyScale;
            //scale.x *= _invertXScale ? -1 : 1;
            instantiate.transform.localScale = scale;
            instantiate.SetActive(true);
        }
    }
}
