using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSceneActiveCanvasController : MonoBehaviour
{
    public GameObject HelpCanvas;
    public GameObject MainCanvas;

    public void EnableHelpCanvas()
    {
        HelpCanvas.SetActive(true);
        MainCanvas.SetActive(false);
    }

    public void EnableMainCanvas()
    {
        HelpCanvas.SetActive(false);
        MainCanvas.SetActive(true);
    }
}
