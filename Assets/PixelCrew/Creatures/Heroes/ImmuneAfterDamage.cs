using PixelCrew.Components.Health;
using PixelCrew.Utils.Disposables;
using System;
using System.Collections;
using UnityEngine;

namespace PixelCrew.Creatures.Heroes
{
    [RequireComponent(typeof(HealthComponent))]
    public class ImmuneAfterDamage : MonoBehaviour
    {
        [SerializeField] private float _immunteTime;
        private HealthComponent _health;
        private Coroutine _coroutine;
        private readonly CompositeDisposable _trash = new CompositeDisposable();

        private void Awake()
        {
            _health = GetComponent<HealthComponent>();
            _trash.Retain(_health._onDamage.Subscribe(OnDamage));
        }

        private void OnDamage()
        {
            TryStop();
            if (_immunteTime > 0)
                _coroutine = StartCoroutine(MakeImmune());
        }

        private void TryStop()
        {
            if (_coroutine != null)
                StopCoroutine(_coroutine);
            _coroutine = null;
        }

        private IEnumerator MakeImmune()
        {
            _health.Immune.Retain(this);
            yield return new WaitForSeconds(_immunteTime);
            _health.Immune.Release(this);
        }

        private void OnDestroy()
        {
            TryStop();
            _trash.Dispose();
        }
    }
}