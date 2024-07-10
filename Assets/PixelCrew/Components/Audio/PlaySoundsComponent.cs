using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelCrew.Components.Audio
{
    public class PlaySoundsComponent : MonoBehaviour
    {
        [SerializeField] private AudioSource _source;
        [SerializeField] private AudioData[] _sounds;

        public void Play(string id)
        {
            foreach (var audiData in _sounds)
            {
                if (audiData.Id != id) continue;
                _source.PlayOneShot(audiData.Clip);
                break;
            }
        }

        [Serializable]
        public class AudioData
        {
            [SerializeField] private string _id;
            [SerializeField] private AudioClip _clip;

            public string Id => _id;
            public AudioClip Clip => _clip;
        }
    }
}
