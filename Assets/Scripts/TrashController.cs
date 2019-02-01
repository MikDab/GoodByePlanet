using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour, OnRightClick, OnLeftClick
{
    Pollution pollution;

    public GameEvent DeselectAllStichijos;
    public GameEvent DefaultClickSound;

    private void Start()
    {
        pollution = FindObjectOfType<Pollution>();
    }

    public void RightClick()
    {
        this.gameObject.SetActive(false);
        this.GetComponentInParent<SpotController>().ClearCurrentlyEnabled();
    }

    public void LeftClick()
    {
        switch (GameController.CurrentlySelectedStichija)
        {
            case Stichija.Audra:
                pollution.IncreasePollution();
                RightClick();
                break;
            case Stichija.Kometos:
                pollution.ReducePollution();
                RightClick();
                break;
            case Stichija.Viesulas:
                pollution.IncreasePollution();
                RightClick();
                break;
            case Stichija.Zaibas:
                pollution.ReducePollution();
                RightClick();
                break;
            default:
                break;
        }

        DeselectAllStichijos.Raise();
        DefaultClickSound.Raise();
    }
}
