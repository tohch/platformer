using PixelCrew.Creatures.Heroes;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

namespace PixelCrew.Components.Audio
{
    public class Echo : MonoBehaviour
    {
        [SerializeField] private AudioMixerGroup _echoVfx;
        [SerializeField] private AudioMixerGroup _echoMusic;

        private AudioMixerGroup _vfxStateChildren;
        private AudioMixerGroup _vfxStateMain;
        private AudioMixerGroup _musicStateChildren;
        private void OnTriggerEnter2D(Collider2D other)
        {
            AudioSource[] childrens = other.GetComponentsInChildren<AudioSource>();
            foreach (var children in childrens)
            {
                if (children.name == "Vfx")
                {
                    _vfxStateChildren = children.outputAudioMixerGroup;
                    children.outputAudioMixerGroup = _echoVfx;
                }
                if (children.name == "MainTheme")
                {
                    _musicStateChildren = children.outputAudioMixerGroup;
                    children.outputAudioMixerGroup = _echoMusic;
                }
            }

            AudioSource item = other.GetComponent<AudioSource>();
            if (item != null)
            {
                _vfxStateMain = item.outputAudioMixerGroup;
                item.outputAudioMixerGroup = _echoVfx;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            AudioSource[] childrens = other.GetComponentsInChildren<AudioSource>();
            foreach (var children in childrens)
            {
                if (children.name == "Vfx")
                {
                    children.outputAudioMixerGroup = _vfxStateChildren;
                }
                if (children.name == "MainTheme")
                {
                    children.outputAudioMixerGroup = _musicStateChildren;
                }
            }

            AudioSource item = other.GetComponent<AudioSource>();
            if (item != null)
            {
                item.outputAudioMixerGroup = _vfxStateMain;
            }
        }
    }
}