using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutTreeController : MonoBehaviour, OnRightClick, OnLeftClick
{
    Polution polution;

    public GameEvent DeselectAllStichijos;

    private void Start()
    {
        polution = FindObjectOfType<Polution>();
    }

    public void RightClick()
    {
        this.gameObject.SetActive(false);
        this.SendMessageUpwards("ClearCurrentlyEnabled");
    }

    public void LeftClick()
    {
        switch (GameController.CurrentlySelectedStichija)
        {
            case Stichija.Audra:
                polution.ReducePolution();
                RightClick();
                break;
            case Stichija.Kometos:
                polution.IncreasePolution();
                RightClick();
                break;
            case Stichija.Viesulas:
                polution.ReducePolution();
                RightClick();
                break;
            case Stichija.Zaibas:
                polution.IncreasePolution();
                RightClick();
                break;
            default:
                break;
        }

        DeselectAllStichijos.Raise();
    }
}
