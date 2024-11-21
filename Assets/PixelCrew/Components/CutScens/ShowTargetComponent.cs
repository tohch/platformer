using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components.CutScens
{
    public class ShowTargetComponent : MonoBehaviour
    {
        [SerializeField] private Transform _target;
        [SerializeField] private CameraStateController _controller;
        [SerializeField] private float _delay = 0.5f;
        [SerializeField] private UnityEvent OnDelay;

        private void OnValidate()
        {
            if (_controller == null)
                _controller = FindObjectOfType<CameraStateController>();
        }

        private void Awake()
        {
            
        }

        public void ShowTarget()
        {
            _controller.SetPosition(_target.position);
            _controller.SetState(true);
            Invoke(nameof(MoveBack), _delay);
        }

        private void MoveBack()
        {
            _controller.SetState(false);

            OnDelay?.Invoke();
        }
    }
}