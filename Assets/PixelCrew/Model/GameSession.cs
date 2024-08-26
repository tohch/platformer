using PixelCrew.Model.Data;
using PixelCrew.Model.Data.Properties;
using PixelCrew.Utils.Disposables;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace PixelCrew.Model
{
    public class GameSession : MonoBehaviour
    {
        [SerializeField] private PlayerData _data;

        //private PlayerData _save;//
        private readonly CompositeDisposable _trash = new CompositeDisposable();

        public QuickInventoryModel QuickInventory { get; private set; }

        public PlayerData Data 
        {
            get => _data;
            set => _data = value;
        }

        private void Awake()
        {
            LoadHud();

            if (IsSessionExit())
            {
                DestroyImmediate(gameObject);
            }
            else
            {
                //Save();//
                InitModels();
                DontDestroyOnLoad(this);
            }
        }

        private void InitModels()
        {
            QuickInventory = new QuickInventoryModel(Data);
            _trash.Retain(QuickInventory);
        }

        private void LoadHud()
        {
            SceneManager.LoadScene("Hud", LoadSceneMode.Additive);
        }

        private bool IsSessionExit()
        {
            var sessions = FindObjectsOfType<GameSession>();
            foreach(var gameSession in sessions)
            {
                if (gameSession != this)
                    return true;
            }
            return false;
        }

        private void OnDestroy()
        {
            _trash.Dispose();
        }
        //public void Save()
        //{
        //    _save = _data.Clone();
        //}
        //public void LoadLastSave()
        //{
        //    _data = _save.Clone();
        //}
    }
}
