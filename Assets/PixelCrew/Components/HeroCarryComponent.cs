using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace PixelCrew.Components
{
    public class HeroCarryComponent : MonoBehaviour
    {
        private bool _isCarry = false;
        private List<GameObject> _objectCarry;
        private void Awake()
        {
            _objectCarry = new List<GameObject>();
        }
        private void FixedUpdate()
        {
            OnCarry(_objectCarry, _isCarry);
        }
        public void SwitchCarry(GameObject gameObject)
        {
            _isCarry = !_isCarry;
            _objectCarry.Add(gameObject);
        }
        public void OnCarry(List<GameObject> gameObject, bool isCarry)
        {
            if (gameObject.Count > 0)
            {
                var collider = gameObject[0].GetComponent<Collider2D>();
                var rigidbody = gameObject[0].GetComponent<Rigidbody2D>();
                if (isCarry)
                {
                    collider.enabled = false;
                    rigidbody.isKinematic = true; ;
                    gameObject[0].transform.position = new Vector2(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 0.1f);
                }
                else if (!isCarry)
                {
                    foreach (var objectCarry in _objectCarry)
                    {
                        if (objectCarry != null && !_isCarry)
                        {
                            objectCarry.GetComponent<Collider2D>().enabled = true;
                            objectCarry.GetComponent<Rigidbody2D>().isKinematic = false;
                        }
                    }
                    _objectCarry.Clear();
                }
            }
        }
    }
}