using PixelCrew.Components.GoBased;
using PixelCrew.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components.LevelManegement
{
    [RequireComponent(typeof(SpawnComponent))]
    public class CheckPointComponent : MonoBehaviour
    {
        [SerializeField] private string _id;
        [SerializeField] private SpawnComponent _heroSpawner;
        [SerializeField] private UnityEvent _setChecked;
        [SerializeField] private UnityEvent _setUnchecked;

        public string Id => _id;
        private GameSession _session;

        private void Start()
        {
            _session = FindObjectOfType<GameSession>();
            if (_session.IsChecked(_id))
                _setChecked?.Invoke();
            else
                _setUnchecked?.Invoke();
        }

        private DataForSpawnItems[] FindAllItemsStatus()
        {
            
            var itemsStatus = FindObjectsOfType<ItemsStatusComponent>();
            DataForSpawnItems[] items = new DataForSpawnItems[itemsStatus.Length];
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = itemsStatus[i].DataForSpawn;
            }

            return items;
        }

        public void Check()
        {
            var items = FindAllItemsStatus();

            _session.SetChecked(_id);

             _session.SetItemsStatus(items);

            _setChecked?.Invoke();
        }

        public void SpawnHero()
        {
            _heroSpawner.Spawn();
        }
    }
}