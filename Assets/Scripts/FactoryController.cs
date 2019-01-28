using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryController : MonoBehaviour, OnRightClick, OnLeftClick
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
                polution.IncreasePolution();
                RightClick();
                break;
            case Stichija.Kometos:
                polution.ReducePolution();
                RightClick();
                break;
            case Stichija.Viesulas:
                polution.IncreasePolution();
                RightClick();
                break;
            case Stichija.Zaibas:
                polution.ReducePolution();
                RightClick();
                break;
            default:
                break;
        }

        DeselectAllStichijos.Raise();
    }
}
