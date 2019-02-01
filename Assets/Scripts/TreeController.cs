using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour, OnRightClick, OnLeftClick
{
    Pollution pollution;
    SpotController spotController;

    public GameEvent DeselectAllStichijos;
    public GameEvent DefaultClickSound;

    private void Start()
    {
        pollution = FindObjectOfType<Pollution>();
        spotController = transform.parent.GetComponent<SpotController>();
    }

    public void RightClick()
    {
        spotController.ClearCurrentlyEnabled();
        this.gameObject.SetActive(false);
    }

    public void LeftClick()
    {
        switch (GameController.CurrentlySelectedStichija)
        {
            case Stichija.Audra:
                spotController.EnableTrees();
                break;

            case Stichija.Kometos:
                pollution.IncreasePollution();
                RightClick();
                break;

            case Stichija.Viesulas:
                pollution.IncreasePollution();
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
        // for now we only play one sound when an object is clicked
        DefaultClickSound.Raise();
        // In future, clicking with different stichijos might use different sounds
    }

}
