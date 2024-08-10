﻿using PixelCrew.Components.Audio;
using System.Collections;
using UnityEngine;

namespace PixelCrew.Utils
{
    public class AudioUtils : MonoBehaviour
    {
        public const string SfxSourceTag = "SfxAudioSource";
        public static AudioSource FindSfxSource()
        {
            return GameObject.FindWithTag(SfxSourceTag).GetComponent<AudioSource>();
        }
    }
}