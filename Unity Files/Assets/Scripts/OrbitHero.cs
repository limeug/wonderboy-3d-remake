using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitHero : MonoBehaviour
{
    public Transform hero;
    private float orbitDst = 8.0f;
    private float orbitDegPerSec = 180.0f;

    // method that makes "Angel" orbit around hero during invincibility
    void Orbit()
    {
        if (hero != null)
        {
            // Keep angel at a certain distance from hero
            transform.position = hero.position + (transform.position - hero.position).normalized * orbitDst;
            transform.RotateAround(hero.position, Vector3.up, orbitDegPerSec * Time.deltaTime);
        }
    }

    //Update is called once per frame
    void LateUpdate()
    {
        Orbit();
    }
}
