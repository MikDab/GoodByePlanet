using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public bool pauseIsActive;
    Canvas pauseCanvas;
    Canvas gameplayCanvas;

    private void Start()
    {
        pauseCanvas = GameObject.Find("PauseCanvas").GetComponent<Canvas>();
        gameplayCanvas = GameObject.Find("GameplayCanvas").GetComponent<Canvas>();

        gameplayCanvas.enabled = false;
        pauseCanvas.enabled = true;

        pauseIsActive = true;
    }

    void loadMenuScene()
    {
        SceneManager.LoadScene(0);
    }

    void ContinuePlay()
    {
        pauseIsActive = false;
        gameplayCanvas.enabled = true;
        pauseCanvas.enabled = false;

    }
}
