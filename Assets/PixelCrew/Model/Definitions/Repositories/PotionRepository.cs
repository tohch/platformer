using PixelCrew.Model.Definitions.Repositories.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelCrew.Model.Definitions.Repositories
{
    [CreateAssetMenu(menuName = "Defs/Potions", fileName = "Postions")]
    public class PotionRepository : DefRepository<PotionDef>
    {
    }

    [Serializable]
    public struct PotionDef : IHaveId
    {
        [InventoryId] [SerializeField] private string _id;
        [SerializeField] private float _value;
        [SerializeField] private float _time;
        public string Id => _id;

        public float Value => _value;

        public float Time => _time;
    }
}
