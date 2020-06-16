using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class npcMovement : MonoBehaviour
{
    //Script control the movement of small fish.
    public float speed = 3.0f;
    [SerializeField] float closeDistance;
    [SerializeField] float longDistance;
    [SerializeField] float EXlongDistance;
    [SerializeField] Transform player;

    float distanceToPlayer = Mathf.Infinity;
    private bool _alive;

    void Start()
    {
        _alive = true;
    }

    void Update()
    {

        checkPlayer();
    }
    public void checkPlayer()
    {
        distanceToPlayer = Vector3.Distance(player.position, transform.position);
        if(transform.position.y <= player.position.y)
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        else
        {
            transform.Translate(0, speed * Time.deltaTime, 0);  
        }
        if (distanceToPlayer >= longDistance)
        {
            speed = 3;
            transform.Translate(speed * Time.deltaTime, 0, 0);
            if (distanceToPlayer >= EXlongDistance)
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
        }
        else if (distanceToPlayer <= longDistance)
        {
            speed = 6;
            transform.Translate(-speed * Time.deltaTime, 0, 0);

            if (transform.position.x > player.position.x)
            {
                speed = 6;
                transform.Translate(speed * 2 * Time.deltaTime, 0, 0);
            }
            else
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }

        }
        if (distanceToPlayer >= EXlongDistance)
        {
            speed = 3;
            transform.Translate(-speed * Time.deltaTime, 0, 0);
            if(transform.position.x <= -290)
            {
                transform.Translate(speed * 2 * Time.deltaTime, 0, 0);
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

    public void SetActive(bool alive)
    {
        _alive = alive;
    }
}
