using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour, OnRightClick, OnLeftClick
{
    Pollution pollution;
    SpotController spotController;

    public GameEvent DeselectAllStichijos;

    private void Start()
    {
        pollution = FindObjectOfType<Pollution>();
        spotController = transform.parent.GetComponent<SpotController>();
    }

    public void RightClick()
    {
        this.gameObject.SetActive(false);
        this.SendMessageUpwards("ClearCurrentlyEnabled");
    }

    public void LeftClick()
    {
        bool isTreeCut = spotController.ShrunkTrees;
        LeftClick(isTreeCut);
        DeselectAllStichijos.Raise();
    }

    private void LeftClick(bool isTreeCut)
    {
        switch (GameController.CurrentlySelectedStichija)
        {
            case Stichija.Audra:
                if (isTreeCut)
                {
                    pollution.ReducePollution();
                    spotController.trees.GetComponent<Animator>().SetTrigger("Grow");
                    spotController.ShrunkTrees = false;
                }
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
    }

}
