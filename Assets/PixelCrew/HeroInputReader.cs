using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroInputReader : MonoBehaviour
{
    [SerializeField]
    private Hero _hero;
    //private void Awake()
    //{
    //    _hero = GetComponent<Hero>();
    //}
    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        _hero.SetDirection(horizontal);
        if (Input.GetButtonUp("Fire1"))
        {
            _hero.SaySomething();
        }
    }
}
