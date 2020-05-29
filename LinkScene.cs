using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LinkScene : MonoBehaviour
{
    public GameObject Panel;
    public void Loadscene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);

    }
    public void Loadscenepop(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
