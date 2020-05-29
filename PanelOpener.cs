using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpener : MonoBehaviour
{
    public GameObject Panel;

   public void OpenPanel()
    {
        if(Panel != null)
        {
            if (Time.timeScale == 1)
                Time.timeScale = 0;
            
            Panel.SetActive(true);
        }
    }
    public void closePanel()
    {
        if (Panel != null)
        {
            if (Time.timeScale == 0)
                Time.timeScale = 1;
            Panel.SetActive(false);
        }
    }
}
