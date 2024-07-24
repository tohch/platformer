using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace PixelCrew.Components
{
    public class ProbabilityDropComponent : MonoBehaviour
    {
        [SerializeField] private int _count;
        [SerializeField] private DropeData[] _drop;
        [SerializeField] private DropeEvent _onDropCalculated;
        [SerializeField] private bool _spawnOnEnable;

        private void OnEnable()
        {
            if (_spawnOnEnable)
            {
                CalculateDrop();
            }
        }
        [ContextMenu("CalculateDrop")]
        public void CalculateDrop()
        {
            var itemsToDrop = new GameObject[_count];
            var itemCount = 0;
            var total = _drop.Sum(dropData => dropData.Probability);
            var sortedDrop = _drop.OrderBy(dropData => dropData.Probability);

            while(itemCount < _count)
            {
                var random = UnityEngine.Random.value * total;
                var current = 0f;
                foreach (var dropData in sortedDrop)
                {
                    current += dropData.Probability;
                    if (current >= random)
                    {
                        itemsToDrop[itemCount] = dropData.Drop;
                        itemCount++;
                        break;
                    }
                }
            }
            _onDropCalculated?.Invoke(itemsToDrop);
        }

        public void SetCount(int count)
        {
            _count = count;
        }
    }

    [Serializable]
    class DropeData
    {
        public GameObject Drop;
        [Range(0f, 100f)] public float Probability;
    }
    [Serializable]
    class DropeEvent : UnityEvent<GameObject[]>
    {

    }
}
