using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;



public class TrashSystem : MonoBehaviour
{
    public Gamedata data;

    public Slider sliderHealthPlayer;
    public Slider sliderHungryPlayer;
    public Text txtTrashcount;
    static public int trashCount;
    public Button trash;
    [SerializeField] float longDistance;
    [SerializeField] Transform player;
    float distanceToPlayer = Mathf.Infinity;

    void Update()
    {
        checkPlayer();
    }
 
    public void checkPlayer()
    {
        distanceToPlayer = Vector3.Distance(player.position, transform.position);
        if (distanceToPlayer <= longDistance)
        {
            sliderHealthPlayer.value -= 0.001f;
            trash.gameObject.SetActive(true);
        }
        else
        {
            trash.gameObject.SetActive(false);
        }
    }
       
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, longDistance);
    }
   
    public void destroytrash()
    {
        NewBehaviourScript.trashCount += 1;
        txtTrashcount.text = NewBehaviourScript.trashCount.ToString();
        sliderHungryPlayer.value -= 0.2f;
        gameObject.SetActive(false);
        //Destroy(other.gameObject); //game crash!!!
        trash.gameObject.SetActive(false);
    }
    
}
