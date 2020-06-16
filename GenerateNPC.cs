using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateNPC : MonoBehaviour
{
    //Manage generate small fish.
    public GameObject NPC;
    public int posX;
    public int posY;

    public int enemyCount = 0;
    public int amountEnemy = 30;
   

    void Update()
    {
        while (enemyCount < amountEnemy)
        {
            posX = Random.Range(-300, 500);
            posY = Random.Range(-56, -300);

            Instantiate(NPC, new Vector3(posX, posY, 0), Quaternion.identity);
            enemyCount += 1;
        }
    }
}
