using PixelCrew.Model;
using UnityEngine;

namespace PixelCrew.Components.GoBased
{
    public class DestroyObjectComponent : MonoBehaviour
    {
        [SerializeField] private GameObject _objectToDestory;
        [SerializeField] private RestorStateComponent _state;

        public void DestoryObject()
        {
            Destroy(_objectToDestory);
            if (_state != null)
                FindObjectOfType<GameSession>().StoreState(_state.Id);
        }
        public void OnDisableCollide()
        {
            gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
