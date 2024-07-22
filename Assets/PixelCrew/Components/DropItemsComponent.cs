using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace PixelCrew.Components
{
    public class DropItemsComponent : MonoBehaviour
    {
        [SerializeField] private int _totalNumberDropItems;
        [SerializeField] private Item[] _typeItems;
        private Transform _positionNextItem;

        public void DropItems()
        {
            for (int i = 0; i < _totalNumberDropItems; i++)
            {
                int indexItem = GetRandomIndex(_typeItems);
                _positionNextItem = gameObject.transform.transform;
                _positionNextItem.position = new Vector3(_positionNextItem.position.x + 0.2f, _positionNextItem.position.y, _positionNextItem.position.z);
                _ = Instantiate(_typeItems[indexItem].Prefab, _positionNextItem.position, Quaternion.identity);
            }
        }
        private int GetRandomIndex(Item[] typeItems)
        {
            Item[] chances = typeItems;
            int chance = UnityEngine.Random.Range(0, 100) + 1;
            for (int index = 0; index < chances.Length; index++)
            {
                var ch = chances[index].Chance;
                if (chance <= ch)
                    return index;
            }
            return UnityEngine.Random.Range(0, chances.Length);
        }
    }
    [Serializable]
    public class Item
    {
        [SerializeField] [Range(0, 100)] private int _chance;
        [SerializeField] private string _name;
        [SerializeField] private GameObject _prefab;
        public string Name => _name;
        public GameObject Prefab => _prefab;
        public int Chance => _chance;
    }

}

