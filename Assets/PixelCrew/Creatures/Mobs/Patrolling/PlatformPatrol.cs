using PixelCrew.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using PixelCrew.Components.ColliderBased;

namespace PixelCrew.Creatures.Mobs.Patrolling
{
    public class PlatformPatrol : Patrol
    {
        [SerializeField] private LayerCheck platformCheck;
        private Creature _creature;
        private Vector3 _direction;

        private void Awake()
        {
            _creature = GetComponent<Creature>();
        }

        public override IEnumerator DoPatrol()
        {
            var pointIndex = 2f;
            while (enabled)
            {
                if (!platformCheck.IsTouchingLayer)
                {
                    _creature.SetDirection(new Vector2(0, 0));
                    pointIndex *= -1f;
                }
                _direction = _creature.transform.position * pointIndex;
                _direction.y = 0;
                _creature.SetDirection(_direction.normalized);
                yield return null;
            }
        }
    }
}
