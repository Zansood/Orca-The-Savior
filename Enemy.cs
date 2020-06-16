using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Enemy : MonoBehaviour
{
    //Set enemy goals And manage the HP of the enemy.
    [SerializeField] float closeDistance;
    [SerializeField] float longDistance;
    [SerializeField] float EXlongDistance;
    [SerializeField] Transform player;

    public GameObject Panel;
    float distanceToPlayer = Mathf.Infinity;

   
    public Slider sliderHealthEM;
    public float speed;
    public PlayerCtrl playerCtrl;

   
    void Update()
    {
        Panel.SetActive(false);
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        if (NewBehaviourScript.trashCount >= 8 )
        {
            if (sliderHealthEM.value >= 1.25f)
            {
                sliderHealthEM.value = 1.25f;
            }
        }
        else
        {
            if (sliderHealthEM.value <= 1.25f)
            {
                sliderHealthEM.value = 2.5f;
            }
        }
        sliderHealthEM.gameObject.SetActive(false);
        if (playerCtrl.sliderHealth.value <= 0)
        {
            longDistance = 0;
            closeDistance = 0;
            EXlongDistance = 0;
        }
        
        //flip sprite 
        checkPlayer();
        if (transform.position.x > player.position.x)
        {
            Flip();
        }
        else
        {
            notFlip();
        }
    }

    public void checkPlayer()
    {
        distanceToPlayer = Vector3.Distance(player.position, transform.position);
        if (distanceToPlayer <= longDistance)
        {
            sliderHealthEM.gameObject.SetActive(true);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else
        {
            sliderHealthEM.gameObject.SetActive(false);
        }
        if (distanceToPlayer >= EXlongDistance)
        {
            transform.position = new Vector3(117.4f,-394.7f, 0);
        }
        if (sliderHealthEM.value <= 1)
        {
            speed = 12
                ;
        }
            if (sliderHealthEM.value <= 0)
        {
            sliderHealthEM.gameObject.SetActive(false);
            Destroy(gameObject);
           
            if(Panel != null)
            {
                Panel.SetActive(true);
                if (Time.timeScale == 1)
                    Time.timeScale = 0;
            }

           
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, closeDistance);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, longDistance);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, EXlongDistance);
    }

    void Flip()
    {
        Vector3 thescale = transform.localScale;
        thescale.z = -2.257215f;
        transform.localScale = thescale;
    }
    void notFlip()
    {
        Vector3 thescale = transform.localScale;
        thescale.z = 2.257215f;
        transform.localScale = thescale;
    }
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            sliderHealthEM.value -= 0.1f;
        }
    }
}
