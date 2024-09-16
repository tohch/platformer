﻿using Cinemachine;
using PixelCrew.Creatures.Heroes;
using UnityEngine;

namespace PixelCrew.Components.LevelManegement
{
    [RequireComponent(typeof(CinemachineVirtualCamera))]
    public class SetFollowComponent : MonoBehaviour
    {
        private void Start()
        {
            var vCamera = GetComponent<CinemachineVirtualCamera>();
            vCamera.Follow = FindObjectOfType<Hero>().transform;
        }
    }
}
