using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteAnimation : MonoBehaviour
    {
        [SerializeField] private int _frameRate;
        [SerializeField] private bool _loop;
        [SerializeField] private bool _allowNextClip;
        [SerializeField] private SubSprites[] _sprites;
        [SerializeField] private UnityEvent _onComplete;


        private SpriteRenderer _renderer;
        private float _secondsPerFrame;
        private int _currentSpriteIndex;
        private float _nexFrameTime;
        private int _nextClip;

        private Sprite[] sprites;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
        }

        private void OnEnable()
        {
            _nextClip = 0;
            _secondsPerFrame = 1f / _frameRate;
            _nexFrameTime = Time.time + _secondsPerFrame;
            _currentSpriteIndex = 0;
        }
        private void Update()
        {
            sprites = _sprites[_nextClip].sprites;
            if (_nexFrameTime > Time.time) return;

            if (_currentSpriteIndex >= sprites.Length)
            {
                if (_loop)
                {
                    _currentSpriteIndex = 0;
                }
                else
                {
                    enabled = false;
                    _onComplete?.Invoke();
                    return;
                }
            }

            _renderer.sprite = sprites[_currentSpriteIndex];
            _nexFrameTime += _secondsPerFrame;
            _currentSpriteIndex++;

            if (_allowNextClip && _currentSpriteIndex >= sprites.Length)
            {
                if (_sprites.Length > _nextClip + 1)
                {
                    _nextClip++;
                    _currentSpriteIndex = 0;
                }
                else if (_loop)
                {
                    _nextClip = 0;
                    _currentSpriteIndex = 0;
                }
            }
        }
    }

    [Serializable]
    public class SubSprites
    {
        public string name; // дополнительное поле, чтобы в инсекторе отобразить имя массива для удобства
        public Sprite[] sprites;
    }
}
