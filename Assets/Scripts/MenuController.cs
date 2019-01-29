using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    // This is bad practice to call scenes by their build number.

    public void PlayScene()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void MenuScene()
    {
        SceneManager.LoadSceneAsync(0);
    }

    public void QuitApllication()
    {
        Application.Quit();
    }
}
