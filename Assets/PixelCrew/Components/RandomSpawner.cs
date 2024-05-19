using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelCrew.Components
{
    public class RandomSpawner : MonoBehaviour
    {
        [SerializeField] private float _sectorAngel;
        [SerializeField] private float _sectorRotaion;
        [SerializeField] private float _waitTime;
        [SerializeField] private float _speed;

        public void StartDrop(GameObject[] objectDrop)
        {
            for (int i = 0; i < objectDrop.Length; i++)
            {
                //int indexItem = GetRandomIndex(_typeItems);
                var _positionNextItem = gameObject.transform.transform;
                _positionNextItem.position = new Vector3(_positionNextItem.position.x + 0.2f, _positionNextItem.position.y, _positionNextItem.position.z);
                var instance = Instantiate(objectDrop[i], _positionNextItem.position, Quaternion.identity);
            }
        }
    }
}
