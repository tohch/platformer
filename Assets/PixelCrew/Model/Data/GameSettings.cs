using PixelCrew.Model.Data.Properties;
using UnityEditor;
using UnityEngine;

namespace PixelCrew.Model.Data
{
    [CreateAssetMenu(menuName = "Data/GameSettings", fileName = "GameSettings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private FloatPersistentProperty Music;
        [SerializeField] private FloatPersistentProperty Sfx;

        private static GameSettings _instance;
        public static GameSettings I => _instance == null ? LoadGameSetting() : _instance;
        private static GameSettings LoadGameSetting()
        {
            return _instance = Resources.Load<GameSettings>("GameSettings");
        }
        private void OnEnable()
        {
            Music = new FloatPersistentProperty(1, SoundsSetting.Music.ToString());
            Sfx = new FloatPersistentProperty(1, SoundsSetting.Sfx.ToString());

        }

        public enum SoundsSetting
        {
            Music,
            Sfx
        }
    }
}