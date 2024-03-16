using System;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components
{
    internal class InteractableComponent : MonoBehaviour
    {
        [SerializeField] private EnterEvent _action;
        public void Interact(GameObject gameObject = null)
        {
            _action?.Invoke(gameObject);
        }

        [Serializable]
        public class EnterEvent : UnityEvent<GameObject>
        {

        }
    }
}
