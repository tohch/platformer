using PixelCrew.Animations;
using PixelCrew.Creatures;
using PixelCrew.Creatures.Heroes;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components.ModifyParam.Speed
{
    public class ModifySpeedComponent : ModifyComponent
    {
        [SerializeField] private float _speedDelta;
        [SerializeField] private float _duringTime;

        private Hero creature;
        private float _defaultSpeed;

        public override void Apply(GameObject target)
        {
            creature = target.GetComponent<Hero>();
            if (creature != null)
            {
                _defaultSpeed = creature.Speed;

                creature.StartCoroutine(ChangeSpeed);
            }
        }

        private void StartChangeSpeed() 
        {
            creature.ChangeSpeed(_speedDelta * _defaultSpeed);
        }
        private void EndChangeSpeed() 
        {
            creature.ChangeSpeed(_defaultSpeed);
        }
        private IEnumerator ChangeSpeed()
        {
            StartChangeSpeed();
            yield return new WaitForSeconds(_duringTime);
            EndChangeSpeed();
        }

        //[Serializable]
        //private class StringEvent : UnityEvent<string> { }
    }
}