using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCtrl : MonoBehaviour
{
    //Control the movement of the player character.
    public static PlayerCtrl instance;
    Rigidbody rb;
    CharacterController charCtrl;
    Animation animat;
    public Gamedata data;

    public float moveSpeed;
    bool facingRight;
    private float moveX;
    private float moveY;
    public GameObject panel;

    public Slider sliderStamina;
    public Slider sliderHealth;
    public Slider sliderHungry;

    private bool isDead = false;


    Collider Hitbox;

    float amountReduce;
    float amountIncrease;

    public float maxStamina;
    public float maxHealth;
    public float maxHungry;
    void Awake()
    {
        Time.timeScale = 1;             
        Hitbox = GetComponent<Collider>();

        charCtrl = GetComponent<CharacterController>();
        rb = GetComponent<Rigidbody>();
        animat = GetComponent<Animation>();

        facingRight = true;
    }
  
    void FixedUpdate()
    {
        if (isDead == true)
            return;
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxis("Vertical");
        transform.position = transform.position + new Vector3(moveX * moveSpeed * Time.deltaTime, moveY * moveSpeed * Time.deltaTime, 0);

        Run();
        hungryStatus();
        healthStatus();

        if (transform.position.y <= -110.3)
        {
            rb.drag = 0.5f;
            rb.useGravity = false;
            sliderHealth.value += 0.0003f;
        }
        else if (transform.position.y <= 0)
        {
            rb.drag = 0;
            rb.useGravity = true;
            sliderHealth.value -= 0.0008f;
        }

        if (sliderStamina.value <= 0)
        {
            moveSpeed = 0 * Time.deltaTime;
        }
        else if (sliderStamina.value > 0 && sliderHealth.value != 0)
        {
            moveSpeed = 10;
        }

        if (moveX > 0 && !facingRight) Flip();
        else if(moveX < 0 && facingRight) Flip();

    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 thescale = transform.localScale;
        thescale.z *= -1;
        transform.localScale = thescale;
    }

    public void Run()
    {
       
        if (Input.GetKey(KeyCode.LeftShift))
        {
            transform.position = transform.position + new Vector3(moveX * moveSpeed * 5 * Time.deltaTime, moveY * moveSpeed * 5 * Time.deltaTime, 0);
            ReduceStamina();
        }
        else
        {
            IncreaseStamina();
            transform.position = transform.position + new Vector3(moveX * moveSpeed * Time.deltaTime, moveY * moveSpeed * Time.deltaTime, 0);
        }
    }

    void ReduceStamina()
    {
        amountReduce = 0.01f;
        if (sliderStamina)
            sliderStamina.value = sliderStamina.value - amountReduce;
    }

    void IncreaseStamina()
    {
        amountReduce = 0.003f;
        if (sliderStamina)
            sliderStamina.value = sliderStamina.value + amountReduce;
    }

    public void healthStatus()
    {
        if (sliderHealth.value <= 0)
        {
            isDead = true;
            print("You are Dead");
            moveSpeed = 0 * Time.deltaTime;
            animat.enabled = false;
            if (panel != null)
                panel.SetActive(true);
            if (Time.timeScale == 1)
                Time.timeScale = 0;
        }
        else if(sliderHealth.value > 0)
        {
            isDead = false;
            moveSpeed = 10;
        }
    }

    public void hungryStatus()
    {
        sliderHungry.value -= 0.00025f;
        if (sliderHungry.value <= 0)
        {
            sliderHealth.value -= 0.001f;
        }
    }
    public void reduceHealthBar(string other)
    {
        switch (other)
        {
            case "YellowNPC":
                amountReduce = 0.2f;
                break;
            case "BlueNPC":
                amountReduce = 0.1f;
                break;

            default:
                break;
        }

        if (sliderHealth)
        {
            sliderHealth.value = sliderHealth.value - amountReduce;
        }
    }
}
