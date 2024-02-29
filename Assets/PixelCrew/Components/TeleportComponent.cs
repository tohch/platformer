using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.PixelCrew.Components
{
    internal class TeleportComponent : MonoBehaviour
    {
        [SerializeField] private Transform _destTrasform;

        public void Teleport(GameObject target)
        {
            Debug.Log("tel");
            target.transform.position = _destTrasform.position;
        }
    }
}
