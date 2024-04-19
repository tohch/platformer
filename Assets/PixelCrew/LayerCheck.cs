using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace PixelCrew
{
    public class LayerCheck : MonoBehaviour
    {
        //[SerializeField] LayerMask _groundLayers;
        //[SerializeField] private bool _isTouchingLayer;
        //public bool IsTouchingLayer 
        //{
        //    get => _isTouchingLayer;
        //    set => _isTouchingLayer = value;
        //}
        //private void Update()
        //{
        //    var hit = Physics2D.CircleCast(transform.position + gameObject.GetComponent<Transform>().localPosition, gameObject.GetComponent<CircleCollider2D>().radius, Vector2.down, 0, _groundLayers);
        //    _isTouchingLayer = hit.collider != null;

        //}
        [SerializeField] private LayerMask _layer;
        [SerializeField] private bool _isTouchingLayer;
        private Collider2D _collider;

        public bool IsTouchingLayer => _isTouchingLayer;

        private void Awake()
        {
            _collider = GetComponent<Collider2D>();
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            _isTouchingLayer = _collider.IsTouchingLayers(_layer);
        }
        private void OnTriggerExit2D(Collider2D collision)
        {
            _isTouchingLayer = _collider.IsTouchingLayers(_layer);
        }
    }
}
