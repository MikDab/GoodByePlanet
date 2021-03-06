﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneActiveCanvasController : MonoBehaviour
{
    public GameObject GameplayCanvas;
    public GameObject PauseCanvas;
    public GameObject EndCanvas;

    public void EnableGameplayCanvas()
    {
        GameplayCanvas.SetActive(true);
        PauseCanvas.SetActive(false);
        EndCanvas.SetActive(false);
    }

    public void EnablePauseCanvas()
    {
        GameplayCanvas.SetActive(false);
        PauseCanvas.SetActive(true);
        EndCanvas.SetActive(false);
    }

    public void EnableEndCanvas()
    {
        GameplayCanvas.SetActive(false);
        PauseCanvas.SetActive(false);
        EndCanvas.SetActive(true);
    }

}
