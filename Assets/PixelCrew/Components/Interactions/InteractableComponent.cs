using PixelCrew.Creatures;
using PixelCrew.Utils;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components.Interactions
{
    internal class InteractableComponent : MonoBehaviour
    {
        [SerializeField] private EnterEvent _action;

        [ContextMenu("Interact")]
        public void Interact(GameObject gameObject = null)
        {
            _action?.Invoke(gameObject);
        }

#if UNITY_EDITOR
        private GameObject[] _gameObjects;

        private void OnValidate()
        {
            _gameObjects = _action.ToGameObjects();
            //_gameObjects = UnityEventExtensions.TryExtractRelations(this);
        }

        public void OnDrawGizmos()
        {
            foreach (var go in _gameObjects)
            {
                if (go == null) continue;

                Debug.DrawLine(transform.position, go.transform.position, Color.green);
            }
        }
#endif


        [Serializable]
        public class EnterEvent : UnityEvent<GameObject>
        {

        }
    }
}
