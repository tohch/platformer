using PixelCrew.Components;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using PixelCrew.Components.ColliderBased;
using PixelCrew.Creatures.Mobs.Patrolling;

namespace PixelCrew.Creatures.Mobs.Patrolling
{
    public class PlatformPatrol : Patrol
    {
        [SerializeField] private LayerCheck platformCheck;
        [SerializeField] private int _direction;
        [SerializeField] private Creature _creature;

        public override IEnumerator DoPatrol()
        {
            while (enabled)
            {
                if (!platformCheck.IsTouchingLayer)
                {
                    _creature.SetDirection(new Vector2(0,0));
                    _direction = -_direction;
                }
                _creature.SetDirection(new Vector2(_direction, 0));
                yield return null;
            }
        }
    }
}
