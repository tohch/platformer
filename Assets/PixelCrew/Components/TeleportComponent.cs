using System;
using System.Collections;
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
            StartCoroutine(VisibleSprite(target));
            target.transform.position = _destTrasform.position;
        }

        private IEnumerator VisibleSprite(GameObject target)
        {
            SpriteRenderer sprite = target.GetComponent<SpriteRenderer>();
            Color color = sprite.material.color;
            color.a = 0f;
            sprite.material.color = color;

            for(float f = 0.05f; f <= 1f; f += 0.05f)
            {
                color = sprite.material.color;
                color.a = f;
                sprite.material.color = color;
                yield return new WaitForSeconds(0.05f);
            }
        }
    }
}
