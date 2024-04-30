﻿using PixelCrew.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelCrew.Creatures
{
    public class PlatformPatrol : Patrol
    {
        [SerializeField] private LayerCheck platformCheck;
        [SerializeField ]private float _waitForTurn = 0.5f;
        private Creature _creature;
        private Vector3 _direction;

        private void Awake()
        {
            _creature = GetComponent<Creature>();
        }

        public override IEnumerator DoPatrol()
        {
            bool registerTouchingLayer = platformCheck.IsTouchingLayer;
            var pointIndex = 2f;
            while (enabled)
            {
                if (!platformCheck.IsTouchingLayer && registerTouchingLayer != platformCheck.IsTouchingLayer)
                {
                    _creature.SetDirection(new Vector2(0,0));
                    pointIndex *= -1f;
                    registerTouchingLayer = !registerTouchingLayer;
                    yield return new WaitForSeconds(_waitForTurn);
                }
                else
                {
                    registerTouchingLayer = platformCheck.IsTouchingLayer;
                }
                _direction = _creature.transform.position * pointIndex;
                _direction.y = 0;
                _creature.SetDirection(_direction.normalized);
                yield return null;
            }
        }
    }
}
