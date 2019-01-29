using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverObject : MonoBehaviour
{
    public GameObject Highlight;

    private void OnMouseOver()
    {
        if (PauseGame.Pause)
            return;

        Highlight.SetActive(true);
        MouseOverData.Instance.CurrentlyActiveController = this.GetComponent<SpotController>();
    }

    private void OnMouseExit()
    {
        Highlight.SetActive(false);
        if(MouseOverData.Instance.CurrentlyActiveController == this.GetComponent<SpotController>())
        MouseOverData.Instance.CurrentlyActiveController = null;
    }

}
