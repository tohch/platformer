using PixelCrew.Model.Data.Properties;
using PixelCrew.Utils;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace PixelCrew.UI.Hud.Dialogs
{
    public class DialogBoxController : MonoBehaviour
    {

        [SerializeField] private Text _text;
        [SerializeField] private GameObject _container;
        [SerializeField] private Animator _animator;

        [Space] [SerializeField] private float _textSpeed = 0.09f;

        [Header("Sounds")] [SerializeField] private AudioClip _typing;
        [SerializeField] private AudioClip _open;
        [SerializeField] private AudioClip _close;

        private DialogData _data;
        private int _currentSencence;
        private AudioSource _sfxSource;

        private void Start()
        {
            _sfxSource = AudioUtils.FindSfxSource();
        }

        public void ShowDialog(DialogData data)
        {
            _data = data;
            _currentSencence = 0;
            _text.text = string.Empty;

            _container.SetActive(true);
            _sfxSource.PlayOneShot(_open);
        }
    }
}