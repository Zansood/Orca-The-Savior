using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class HitCtrl : MonoBehaviour
{
    //Control of collisions with objects and saving and loading
    public GenerateNPC GNPC;
    public Gamedata data;
    string datafilePath;
    BinaryFormatter bf;

    public Text score;
    public Text time;
    public Text txtcoinCount;
    public Text scoreResult;
    public Text timeResult;
    public Text txtcoinCountResult;

    public Slider sliderHealthEM;
    public Slider sliderHealth;
    public Slider sliderHungry;
    public Slider sliderStamina;

    public GameObject VFXAttackgreen, VFXAttackBlue, VFXTreasure;
    public AudioClip SoundAttackgreen, SoundAttackBlue, SoundTreasure;


    float amountIncrease;

    public Collider Hitbox;
    // Start is called before the first frame update
    private void Awake()
    {
        bf = new BinaryFormatter();
        datafilePath = Application.persistentDataPath + "/game.dat";

       
    }
    void Start()
    {
        Hitbox = GetComponent<Collider>();
       
    }

   public void Savedata()
    {
        FileStream fs = new FileStream(datafilePath, FileMode.Create);
        bf.Serialize(fs,data);
        fs.Close();
    }
    public void Loaddata()
    {
        if (File.Exists(datafilePath))
        {
            FileStream fs = new FileStream(datafilePath, FileMode.Open);
            data = (Gamedata)bf.Deserialize(fs);
            fs.Close();
            sliderHealth.maxValue = data.maxHP;
            sliderHungry.maxValue = data.maxHung;
            sliderStamina.maxValue = data.maxStam;
            sliderHungry.value = sliderHungry.maxValue;
            sliderHealth.value = sliderHealth.maxValue;
            sliderStamina.value = sliderStamina.maxValue;
            txtcoinCount.text = data.coinCount.ToString();
            score.text = data.score.ToString();
            time.text = data.time.ToString();
            timeResult.text = data.time.ToString("f2");
            txtcoinCountResult.text = data.coinCount.ToString();
            scoreResult.text = data.score.ToString();


        }
    }
    private void OnEnable()
    {
        Debug.Log("loaddata");
        Debug.Log(Application.persistentDataPath);
        Loaddata();
    }
    private void OnDisable()
    {
        Debug.Log("savedata");
        //data.coinCount = 0;
     
        
        Savedata();
    }
    void Update()
    {
        timeUpdate();
      
        /*score = scoreResult;
        time = timeResult;
        txtcoinCount = txtcoinCountResult;*/
        

}

    void timeUpdate()
    {
        data.time += Time.deltaTime;
        time.text = data.time.ToString("f2");
        timeResult.text = data.time.ToString("f2");
    }

    public void updatecoinCount()
    {
        data.coinCount += 1;
        txtcoinCount.text = data.coinCount.ToString();
        txtcoinCountResult.text = data.coinCount.ToString();
        data.score += 20;
        score.text = data.score.ToString();
        scoreResult.text = data.score.ToString();
    }
    public void updatecoinCountBoss()
    {
        data.coinCount += 250;
        txtcoinCount.text = data.coinCount.ToString();
        txtcoinCountResult.text = data.coinCount.ToString();
        data.score += 5000;
        score.text = data.score.ToString();
        scoreResult.text = data.score.ToString();
    }
    public void updatecoinCountTreasure()
    {
        data.coinCount += Random.Range(10, 50);
        txtcoinCount.text = data.coinCount.ToString();
        txtcoinCountResult.text = data.coinCount.ToString();        
    }


    public void OnCollisionEnter(Collision other)
    {
        ParticleCtrl(other.gameObject.tag);
        PlaySoundCtrl(other.gameObject.tag);
       
        if (other.gameObject.tag == "greenNPC")
        {
            IncreaseHungryBar(other.gameObject.tag);//IncreaseHungryBar(other.gameObject.tag);
            updatecoinCount();
            Destroy(other.gameObject);
            GNPC.enemyCount -= 1;
            
            Debug.Log("123");
        }
        if (other.gameObject.tag == "Treasure")
        {
            updatecoinCountTreasure();
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "YellowNPC")
        {
            if (sliderHealthEM.value <= 0.1f)
            {
                updatecoinCountBoss();
            }
            sliderHealth.value -= 0.2f;
        }
    }
    
    void ParticleCtrl(string other)
    {
        switch (other)
        {
            case "greenNPC":
                SFXCtrl.instance.ShowAttackParticle(gameObject.transform.position, VFXAttackgreen);
                break;
            case "YellowNPC":
                SFXCtrl.instance.ShowAttackParticle(gameObject.transform.position, VFXAttackBlue);
                break;
            case "Treasure":
                SFXCtrl.instance.ShowAttackParticle(gameObject.transform.position, VFXTreasure);
                break;

            default:
                break;
        }
    }

    void PlaySoundCtrl(string other)
    {
        switch (other)
        {
            case "greenNPC":
                SoundCtrl.instance.PlaySound(gameObject.transform.position, SoundAttackgreen);
                break;
            case "YellowNPC":
                SoundCtrl.instance.PlaySound(gameObject.transform.position, SoundAttackBlue);
                break;
            case "Treasure":
                SoundCtrl.instance.PlaySound(gameObject.transform.position, SoundTreasure);
                break;

            default:
                break;
        }
    }

    public void IncreaseHungryBar(string other)
    {
        switch (other)
        {
            case "greenNPC":
                amountIncrease = 0.1f;
                break;

            case "yellowNPC":
                amountIncrease = 0.5f;
                break;

            case "redNPC":
                amountIncrease = 0.7f;
                break;

            default:
                break;

        }

        if (sliderHungry)
        {
            sliderHungry.value = sliderHungry.value + amountIncrease;
        }

    }

}
