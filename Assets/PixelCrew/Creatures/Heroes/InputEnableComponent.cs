using UnityEngine;
using UnityEngine.InputSystem;

namespace PixelCrew.Creatures.Heroes
{
    public class InputEnableComponent : MonoBehaviour
    {
        private PlayerInput _input;

        // Use this for initialization
        private void Start()
        {
            _input = FindObjectOfType<PlayerInput>();
        }

        public void SetInput(bool isEnable)
        {
            _input.enabled = isEnable;
        }
    }
}