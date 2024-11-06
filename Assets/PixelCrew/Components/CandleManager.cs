using PixelCrew.Components.CutScens;
using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace PixelCrew.Components
{
    public class CandleManager : MonoBehaviour
    {
        [SerializeField] private GameObject _candle;
        [SerializeField] private float _secondForTurnoff;
        private float _timerForTurnoff;


        private CandleManager _candleManager;
        private Light2D _light;
        private bool _flagIsStartTurnoff;

        public void TurnOn(GameObject go)
        {
            if (_candleManager == null)
                _candleManager = go.GetComponent<CandleManager>();

            _candleManager._candle.SetActive(true);

            _candleManager._timerForTurnoff = Time.time + _secondForTurnoff;
        }

        public void Update()
        {
            if (Time.time > _timerForTurnoff && !_flagIsStartTurnoff)
                TurnOff();
        }

        public void TurnOff()
        {
            if (_candle == null) return;
            if (!_candle.activeInHierarchy) return;
            _flagIsStartTurnoff = true;
            StartCoroutine(StartSmoothTurnOff());
        }

        private IEnumerator StartSmoothTurnOff()
        {
            _light = _candle.GetComponentInChildren<Light2D>();
            
            var defaultRaiousInner = _light.pointLightOuterRadius;
            var defaultRaiousOut = _light.pointLightInnerRadius;
            var innerRadiousDelta = _light.pointLightInnerRadius / _light.pointLightOuterRadius;
            
            for (float f = _light.pointLightOuterRadius; f >= 0; f -= 0.05f)
            {
                _light.pointLightOuterRadius = f;
                _light.pointLightInnerRadius -= innerRadiousDelta;
                yield return new WaitForSeconds(Time.deltaTime);
            }

            _candle.SetActive(false);

            _light.pointLightOuterRadius = defaultRaiousInner;
            _light.pointLightInnerRadius = defaultRaiousOut;
            _flagIsStartTurnoff = false;
        }
    }
}