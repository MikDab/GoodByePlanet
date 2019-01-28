using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    Canvas helpCanvas;
    Canvas mainCanvas;

    private void Start()
    {
        mainCanvas = GameObject.Find("MenuCanvas").GetComponent<Canvas>();
        helpCanvas = GameObject.Find("HelpCanvas").GetComponent<Canvas>();
        helpCanvas.enabled = false;

        helpCanvas.enabled = false;
    }

    public void PlayScene()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void QuitApllication()
    {
        Application.Quit();
    }

    public void HelpCanvas()
    {
        mainCanvas.enabled = false;
        helpCanvas.enabled = true;
    }

    public void MenuCanvas()
    {
        helpCanvas.enabled = false;
        mainCanvas.enabled = true;
        
    }

}
