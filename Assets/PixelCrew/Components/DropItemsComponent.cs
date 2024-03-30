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
        private Transform _trarget;
        private void Awake()
        {
            _trarget = gameObject.transform.transform;
        }
        public void DropItems()
        {
            for (int i = 0; i < _totalNumberDropItems; i++)
            {
                _positionNextItem = gameObject.transform.transform;
                //foreach (var item in _typeItems)
                //{
                    _positionNextItem.position = new Vector3(_positionNextItem.position.x + 0.2f, _positionNextItem.position.y, _positionNextItem.position.z);
                    var instance = Instantiate(_typeItems[0].Prefab, _positionNextItem.position, Quaternion.identity);
                //}
            }
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
    }

}

