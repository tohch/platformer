﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew
{
    public class DestroyObjectComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToDestory;
        public void DestoryObject()
        {
            Destroy(_objectToDestory);
        }
    }
}
