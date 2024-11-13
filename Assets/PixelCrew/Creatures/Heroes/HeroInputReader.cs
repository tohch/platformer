using PixelCrew.Creatures;
using UnityEngine;
using UnityEngine.InputSystem;
using PixelCrew.Creatures.Heroes;
using System;

namespace PixelCrew.Creatures
{
    public class HeroInputReader : MonoBehaviour
    {
        [SerializeField] private Hero _hero;

        public void OnMovement(InputAction.CallbackContext context)
        {
            var direction = context.ReadValue<Vector2>();
            _hero.SetDirection(direction);
        }

        public void OnInteract(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _hero.Interact();
            }
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                _hero.Attack();
            }
        }

        public void OnThrow(InputAction.CallbackContext context)
        {
            if (context.started)
            {
                _hero.StartThrowing();
            }
            if (context.canceled)
            {
                _hero.UseInventory();
            }
        }

        public void OnUsePotion(InputAction.CallbackContext contex)
        {
            if (contex.performed)
            {
                _hero.UseHealPotion();
            }
        }

        public void OnDrop(InputAction.CallbackContext contex)
        {
            if (contex.performed)
            {
                _hero.DropFromPlatform();
            }
        }

        public void OnNextItem(InputAction.CallbackContext context)
        {
            if (context.performed)
                _hero.NextItem();
        }

        public void OnUsePerk(InputAction.CallbackContext context)
        {
            if (context.performed)
                _hero.UsePerk();
        }
    }
}
