﻿using PixelCrew.Components.GoBased;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PixelCrew.Creatures.Mobs.Boss.Bombs
{
    public class BombsController : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _platforms;
        [SerializeField] private BombSequence[] _sequences;
        private Coroutine _coroutine;

        [ContextMenu("Start bombing")]
        public void StartBoming()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);

            _coroutine = StartCoroutine(BombingSequence());
        }

        private IEnumerator BombingSequence()
        {
            _platforms.ForEach(x => x.SetActive(false));
            foreach (var bombSequence in _sequences)
            {
                foreach (var spawnComponent in bombSequence.BombPoints)
                {
                    spawnComponent.Spawn();
                }

                yield return new WaitForSeconds(bombSequence.Delay);
            }

            _platforms.ForEach(x => x.SetActive(true));
            
            _coroutine = null;
        }

        [Serializable]
        public class BombSequence
        {
            [SerializeField] private SpawnComponent[] _bombPoints;
            [SerializeField] private float _delay;

            public SpawnComponent[] BombPoints => _bombPoints;
            public float Delay => _delay;
        }
    }
}