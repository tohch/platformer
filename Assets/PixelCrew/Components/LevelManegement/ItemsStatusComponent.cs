using PixelCrew.Components.GoBased;
using System.Collections;
using UnityEngine;

namespace PixelCrew.Components.LevelManegement
{
    [RequireComponent(typeof(SpawnComponent))]
    public class ItemsStatusComponent : MonoBehaviour
    {
        private SpawnComponent _spawner;

        // Use this for initialization
        void Start()
        {
            _spawner = GetComponent<SpawnComponent>();
            _spawner.Spawn();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}