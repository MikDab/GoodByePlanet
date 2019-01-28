using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeController : MonoBehaviour, OnRightClick, OnLeftClick
{
    Polution polution;
    SpotController spotController;

    public GameEvent DeselectAllStichijos;

    private void Start()
    {
        polution = FindObjectOfType<Polution>();
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
                    polution.ReducePolution();
                    spotController.trees.GetComponent<Animator>().SetTrigger("Grow");
                    spotController.ShrunkTrees = false;
                }
                break;
            case Stichija.Kometos:
                polution.IncreasePolution();
                RightClick();
                break;
            case Stichija.Viesulas:
                polution.IncreasePolution();
                RightClick();
                break;
            case Stichija.Zaibas:
                polution.IncreasePolution();
                RightClick();
                break;
            default:
                break;
        }
    }

}
