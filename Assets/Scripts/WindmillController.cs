using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillController : MonoBehaviour
{
    public GameEvent DeselectAllStichijos;
    public GameEvent DefaultClickSound;

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
                this.gameObject.SetActive(false);
                break;
            case Stichija.Kometos:
                this.gameObject.SetActive(false);
                break;
            case Stichija.Viesulas:
                this.gameObject.SetActive(false);
                break;
            case Stichija.Zaibas:
                this.gameObject.SetActive(false);
                break;
            default:
                break;
        }

        DeselectAllStichijos.Raise();
        DefaultClickSound.Raise();
    }
}
