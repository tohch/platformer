﻿using UnityEngine;
using UnityEngine.InputSystem;

namespace PixelCrew
{
    public class HeroInputReader : MonoBehaviour
    {
        [SerializeField] private Hero _hero;
        public void OnMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            _hero.SetDirection(direction);
        }
        public void OnSay(InputAction.CallbackContext context)
        {
            if (context.canceled)
            {
                _hero.SaySomething();
            }
        }
    }
}
