using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class SpriteAnimation : MonoBehaviour
    {
        [SerializeField] [Range(1, 30)] private int _frameRate = 10;
        [SerializeField] private UnityEvent<string> _onComplete;
        [SerializeField] private AnimationClip[] _clips;

        private SpriteRenderer _renderer;

        private float _secPerFrame;
        private float _nextFrameTime;
        private int _currentFrame;
        private bool _isPlaying = true;

        private int _currentClip;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _secPerFrame = 1f / _frameRate;

            StartAnimation();
        }
        
        private void OnBecameVisible()
        {
            enabled = _isPlaying;
        }
        private void OnBecameInvisible()
        {
            enabled = false;
        }
        public void SetClip(string clipName)
        {
            for (var i = 0; i < _clips.Length; i++) 
            { 
                if (_clips[i].Name == clipName)
                {
                    _currentClip = i;
                    StartAnimation();
                    return;
                }
            }

            enabled = _isPlaying = false;
        }
        private void StartAnimation()
        {
            _nextFrameTime = Time.time + _secPerFrame;
            _isPlaying = true;
            _currentFrame = 0;
        }

        private void OnEnable()
        {
            _nextFrameTime = Time.time + _secPerFrame;
        }

        private void Update()
        {
            if (_nextFrameTime > Time.time) return;

            var clip = _clips[_currentClip];
            if (_currentFrame >= clip.Sprites.Length)
            {
                if (clip.Loop)
                {
                    _currentFrame = 0;
                }
                else
                {
                    clip.onComplete?.Invoke();
                    _onComplete?.Invoke(clip.Name);
                    enabled = _isPlaying = clip.AllowNextClip;
                    if (clip.AllowNextClip)
                    {
                        _currentFrame = 0;
                        _currentClip = (int)Mathf.Repeat(_currentClip + 1, _clips.Length);
                    }
                }
                return;
            }

            _renderer.sprite = clip.Sprites[_currentFrame];

            _nextFrameTime += _secPerFrame;
            _currentFrame++;

        }
        //    [SerializeField] [Range(1, 30)] private int _frameRate = 10;
        //    [SerializeField] private bool _loop;
        //    [SerializeField] private bool _allowNextClip;
        //    [SerializeField] private SubSprites[] _sprites;
        //    [SerializeField] private UnityEvent _onComplete;


        //    private SpriteRenderer _renderer;
        //    private float _secondsPerFrame;
        //    private int _currentSpriteIndex;
        //    private float _nexFrameTime;
        //    private int _nextClip;

        //    private Sprite[] sprites;

        //    private void Start()
        //    {
        //        _renderer = GetComponent<SpriteRenderer>();
        //    }

        //    private void OnEnable()
        //    {
        //        _nextClip = 0;
        //        _secondsPerFrame = 1f / _frameRate;
        //        _nexFrameTime = Time.time + _secondsPerFrame;
        //        _currentSpriteIndex = 0;
        //    }
        //    private void Update()
        //    {
        //        sprites = _sprites[_nextClip].sprites;
        //        if (_nexFrameTime > Time.time) return;

        //        if (_currentSpriteIndex >= sprites.Length)
        //        {
        //            if (_loop)
        //            {
        //                _currentSpriteIndex = 0;
        //            }
        //            else
        //            {
        //                enabled = false;
        //                _onComplete?.Invoke();
        //                return;
        //            }
        //        }

        //        _renderer.sprite = sprites[_currentSpriteIndex];
        //        _nexFrameTime += _secondsPerFrame;
        //        _currentSpriteIndex++;

        //        if (_allowNextClip && _currentSpriteIndex >= sprites.Length)
        //        {
        //            if (_sprites.Length > _nextClip + 1)
        //            {
        //                _nextClip++;
        //                _currentSpriteIndex = 0;
        //            }
        //            else if (_loop)
        //            {
        //                _nextClip = 0;
        //                _currentSpriteIndex = 0;
        //            }
        //        }
        //    }
        //}

        //[Serializable]
        //public class SubSprites
        //{
        //    public string name; // дополнительное поле, чтобы в инсекторе отобразить имя массива для удобства
        //    public Sprite[] sprites;
    }
    [Serializable]
    public class AnimationClip
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private bool _loop;
        [SerializeField] private bool _allowNextClip;
        [SerializeField] private UnityEvent _onComplete;
        public string Name => _name;
        public Sprite[] Sprites => _sprites;
        public bool Loop => _loop;
        public bool AllowNextClip => _allowNextClip;
        public UnityEvent onComplete => _onComplete;
    }
}
