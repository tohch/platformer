using PixelCrew.Model.Data.Properties;
using PixelCrew.Utils;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrew.UI.Hud.Dialogs
{
    public class DialogBoxController : MonoBehaviour
    {

        [SerializeField] private Text _text;
        [SerializeField] private GameObject _container;
        [SerializeField] private GameObject _face;
        [SerializeField] private Animator _animator;

        [Space] [SerializeField] private float _textSpeed = 0.09f;

        [Header("Sounds")] [SerializeField] private AudioClip _typing;
        [SerializeField] private AudioClip _open;
        [SerializeField] private AudioClip _close;

        private static readonly int IsOpenRight = Animator.StringToHash("IsOpenRight");
        private static readonly int IsOpenLeft = Animator.StringToHash("IsOpenLeft");

        private Image _faceAvatar;
        private DialogData _data;
        private int _currentSencence;
        private AudioSource _sfxSource;
        private Coroutine _typingRoutine;

        private void Start()
        {
            _faceAvatar = _face.GetComponent<Image>();
            _sfxSource = AudioUtils.FindSfxSource();
        }

        public void ShowDialog(DialogData data)
        {
            _data = data;
            _currentSencence = 0;
            _text.text = string.Empty;
            _faceAvatar.sprite = _data.Avatar;

            _container.SetActive(true);
            _face.SetActive(true);
            _sfxSource.PlayOneShot(_open);
            //_animator.SetBool(IsOpenRight, true);
            StartAnimation();
        }

        private void StartAnimation()
        {
            switch (_data.PositionDialogContainer)
            {
                case DialogData.PositionDialog.Left:
                    _animator.SetBool(IsOpenLeft, true);
                    break;
                case DialogData.PositionDialog.Right:
                    _animator.SetBool(IsOpenRight, true);
                    break;
            }
        }

        private IEnumerator TypeDialogText()
        {
            _text.text = string.Empty;
            var sentences = _data.Sentences[_currentSencence];
            foreach(var letter in sentences)
            {
                _text.text += letter;
                _sfxSource.PlayOneShot(_typing);
                yield return new WaitForSeconds(_textSpeed);
            }

            _typingRoutine = null;
        }

        public void OnSkip()
        {
            if (_typingRoutine == null) return;

            StopTypeAnimation();
            _text.text = _data.Sentences[_currentSencence];
        }

        public void OnContinue()
        {
            StopTypeAnimation();
            _currentSencence++;

            var isDialogCompleted = _currentSencence >= _data.Sentences.Length;
            if (isDialogCompleted)
            {
                HideDialogBox();
            }
            else
            {
                OnStartDialogAnimation();
            }
        }

        private void HideDialogBox()
        {
            _animator.SetBool(IsOpenRight, false);
            _animator.SetBool(IsOpenLeft, false);
            _sfxSource.PlayOneShot(_close);
        }

        private void StopTypeAnimation()
        {
            if (_typingRoutine != null)
                StopCoroutine(_typingRoutine);
            _typingRoutine = null;
        }

        public void OnStartDialogAnimation()
        {
            _typingRoutine = StartCoroutine(TypeDialogText());
        }


        public void OnCloseAnimationComplete()
        {

        }
    }
}