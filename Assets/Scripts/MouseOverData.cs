using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverData : MonoBehaviour
{
    public static MouseOverData Instance { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
            return;
        }
    }
    public SpotController CurrentlyActiveController;

    void Update()
    {
        if (GameController.Instance.Pause)
            return;

        if (Input.GetMouseButtonDown(0))
        {
            if (GameController.CurrentlySelectedStichija != Stichija.Nothing)
            {
                if (CurrentlyActiveController != null)
                {
                    CurrentlyActiveController.GetComponent<OnLeftClick>().LeftClick();
                }
            }
        }

        //if (Input.GetMouseButtonDown(1))
        //{
        //    if (CurrentlyActiveController != null)
        //    {
        //        CurrentlyActiveController.GetComponent<OnRightClick>().RightClick();
        //    }
        //}
    }
}
