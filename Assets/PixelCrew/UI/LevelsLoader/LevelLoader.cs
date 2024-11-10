using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelCrew.UI.LevelsLoader
{
    public class LevelLoader : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void OnFaterSceneLoade()
        {
            InitLoader();
        }

        private static LevelLoader Instance;

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private static void InitLoader()
        {
            if (Instance != null)
                SceneManager.LoadScene("LevelLoader", LoadSceneMode.Additive);
        }

        public void Show(string sceneName)
        {

        }
    }
}