using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroInputReader : MonoBehaviour
{
    private Hero _hero;
    private void Awake()
    {
        _hero = GetComponent<Hero>();
    }
    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        _hero.SetDirection(horizontal);
        //if (Input.GetAxis("Horizontal"))
        //{

        //}
        //if (Input.GetKey(KeyCode.A))
        //{
        //    _hero.SetDirection(-1);
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    _hero.SetDirection(1);
        //}
        //else
        //{
        //    _hero.SetDirection(0);
        //}
    }
}
