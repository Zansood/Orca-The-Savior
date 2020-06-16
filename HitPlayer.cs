using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HitPlayer : MonoBehaviour
{
    //Control the collision with the enemy.
    public Slider sliderHealthPlayer;
    public Collider Hitbox;

    void Start()
    {
        Hitbox = GetComponent<Collider>();
    }

    public void OnCollisionEnter(Collision other2)
    {
        if(other2.gameObject.tag == "Player")
        {
            sliderHealthPlayer.value -= 1;
        }
    }
}
