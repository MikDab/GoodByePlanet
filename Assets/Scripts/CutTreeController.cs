using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutTreeController : MonoBehaviour, OnRightClick, OnLeftClick
{
    Pollution pollution;

    public GameEvent DeselectAllStichijos;

    private void Start()
    {
        pollution = FindObjectOfType<Pollution>();
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
                pollution.ReducePollution();
                RightClick();
                break;
            case Stichija.Kometos:
                pollution.IncreasePollution();
                RightClick();
                break;
            case Stichija.Viesulas:
                pollution.ReducePollution();
                RightClick();
                break;
            case Stichija.Zaibas:
                pollution.IncreasePollution();
                RightClick();
                break;
            default:
                break;
        }

        DeselectAllStichijos.Raise();
    }
}
