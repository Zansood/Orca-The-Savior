using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class npcCtrl : MonoBehaviour
{
    Rigidbody rb2;
    bool facingRight2;
    int posX;
    int posY;
    NavMeshAgent navMeshAgent;
    public float timeforNewPath;
    bool inCoRoutine;
    
    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        rb2 = GetComponent<Rigidbody>();
        facingRight2 = true;
        posX = Random.Range(-300, 500);
        posY = Random.Range(-56, -300);


    }

    Vector3 getNewRandomPosition()
    {
        float x = Random.Range(-20, 20);
        float y = Random.Range(-20, 20);
        Vector3 pos = new Vector3(x, y, 0);
        return pos;
    }
    IEnumerator doSomething()
    {
        inCoRoutine = true;
        yield return new WaitForSeconds(timeforNewPath);
        getNewPath();
        inCoRoutine = false;
    }
    void getNewPath()
    {
        //.SetDestination(getNewRandomPosition());
    }
    void FixedUpdate()
    {
        //transform.position += new Vector3(posX,posY,0);

        if(!inCoRoutine)
        {
            StartCoroutine(doSomething());
        }
        if(transform.position.y <= -110.3)
        {
            rb2.drag = 0.5f;
            rb2.useGravity = false;
            //rb.velocity = new Vector3(moveX * runspeed, moveY * runspeed, 0);
        }
        else if(transform.position.y <= 0)
        {
            rb2.drag = 0;
            rb2.useGravity = true;
            //rb.velocity = new Vector3(moveX, moveY, 0);

        }

       
    }

}
