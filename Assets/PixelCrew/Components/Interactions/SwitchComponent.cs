﻿using UnityEngine;

namespace PixelCrew.Components.Interactions
{
    internal class SwitchComponent : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private bool _state;
        [SerializeField] private string _animationKey;
        [SerializeField] private bool _updateOnStart;

        private void Start()
        {
            if (_updateOnStart)
                _animator.SetBool(_animationKey, _state);
        }

        public void Switch()
        {
            _state = !_state;
            _animator.SetBool(_animationKey, _state);
        }

        [ContextMenu("Switch")]
        public void SwitchIt()
        {
            Switch();
        }
    }
}
