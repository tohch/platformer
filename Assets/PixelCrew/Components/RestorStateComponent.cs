using PixelCrew.Model;
using UnityEngine;

namespace PixelCrew.Components
{
    public class RestorStateComponent : MonoBehaviour
    {
        [SerializeField] private string _id;
        public string Id => _id;

        private GameSession _session;
        void Start()
        {
            _session = FindObjectOfType<GameSession>();
            var isDestroyed = _session.RestoreState(_id);
            if (isDestroyed)
                Destroy(gameObject);
        }
    }
}