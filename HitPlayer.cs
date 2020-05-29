using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HitPlayer : MonoBehaviour
{
    public Slider sliderHealthPlayer;
    public Collider Hitbox;

    // Start is called before the first frame update
    void Start()
    {
        Hitbox = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision other2)
    {
        if(other2.gameObject.tag == "Player")
        {
            sliderHealthPlayer.value -= 1;
        }
    }
}
