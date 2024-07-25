﻿using System.Collections;
using UnityEngine;

namespace PixelCrew.Components.GoBased
{
    public class GoContainerComponent : MonoBehaviour
    {
        [SerializeField] private GameObject[] _gos;
        [SerializeField] private DropeEvent _onDrop;

        [ContextMenu("Drop")]
        public void Drop()
        {
            _onDrop.Invoke(_gos);
        }
    }
}