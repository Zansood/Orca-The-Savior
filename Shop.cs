using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class Shop : MonoBehaviour
{
    //Script to upgrade various characters.
    public Gamedata data;
    public Text txtcoinCount;
    string datafilePath;
    public Text hp, stam, hung;
    BinaryFormatter bf;

    private void Awake()
    {
        bf = new BinaryFormatter();
        datafilePath = Application.persistentDataPath + "/game.dat";
    }
    public void Savedata()
    {
        FileStream fs = new FileStream(datafilePath, FileMode.Create);
        bf.Serialize(fs, data);
        fs.Close();
    }
    public void Loaddata()
    {
        if (File.Exists(datafilePath))
        {
            FileStream fs = new FileStream(datafilePath, FileMode.Open);
            data = (Gamedata)bf.Deserialize(fs);
            fs.Close();
            txtcoinCount.text = data.coinCount.ToString();
            hp.text = data.HP.ToString();
            stam.text = data.Stam.ToString();
            hung.text = data.Hung.ToString();
        }
    }
    private void OnEnable()
    {
        Debug.Log("loaddata");
        Loaddata();
    }
    private void OnDisable()
    {
        Debug.Log("savedata");
        Savedata();
       
        
    }

    public void HPupgrade()
    {
        if (data.coinCount >= 10)
        {
            data.HP += 1;
            hp.text = data.HP.ToString();

            data.coinCount -= 10;
            txtcoinCount.text = data.coinCount.ToString();
            data.maxHP += 0.1f;
            //PlayerCtrl.instance.maxHealth += 1;
        }
      
    }
    public void Stamupgrade()
    {
        if (data.coinCount >= 10)
        {
            data.Stam += 1;
            stam.text = data.Stam.ToString();

            data.coinCount -= 10;
            txtcoinCount.text = data.coinCount.ToString();
            data.maxStam += 0.1f;
        }
    }

    public void Hungupgrade()
    {
        if (data.coinCount >= 10)
        {
            data.Hung += 1;
            hung.text = data.Hung.ToString();

            data.coinCount -= 10;
            txtcoinCount.text = data.coinCount.ToString();
            data.maxHung += 0.1f;
            //playerCtrl.maxHungry += 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
}
