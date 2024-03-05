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
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private UnityEvent _onComplete;
        [SerializeField] private SubSprites[] myArray;


        private SpriteRenderer _renderer;
        private float _secondsPerFrame;
        private int _currentSpriteIndex;
        private float _nexFrameTime;

        private void Start()
        {
            _renderer = GetComponent<SpriteRenderer>();
            //myArray2.Add(34);
        }

        private void OnEnable()
        {
            _secondsPerFrame = 1f / _frameRate;
            _nexFrameTime = Time.time + _secondsPerFrame;
            _currentSpriteIndex = 0;
        }
        private void Update()
        {
            //Debug.Log(myArray[0].list[0]);
            if(myArray.Length != 0) 
            {
                if (myArray[0].sprites.Length != 0)
                    Debug.Log(myArray[0].sprites[0]);
            }
            if (_nexFrameTime > Time.time) return;

            if (_currentSpriteIndex >= _sprites.Length)
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
            _renderer.sprite = _sprites[_currentSpriteIndex];
            _nexFrameTime += _secondsPerFrame;
            _currentSpriteIndex++;
        }

    }

    [Serializable]
    public class SubSprites
    {
        public string name; // дополнительное поле, чтобы в инсекторе отобразить имя массива для удобства
        public int[] sprites;
    }
}
