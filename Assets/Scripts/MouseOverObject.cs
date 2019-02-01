using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOverObject : MonoBehaviour
{
    public GameObject Highlight;
    public bool HighlightActive = true;

    void Start()
    {
        
    }

    private void OnMouseOver()
    {
        if (GameController.Instance.Pause)
            return;

        if(HighlightActive)
        Highlight.SetActive(true);

        MouseOverData.Instance.CurrentlyActiveController = this.GetComponent<SpotController>();
    }

    private void OnMouseExit()
    {
        if(HighlightActive)
        Highlight.SetActive(false);

        if(MouseOverData.Instance.CurrentlyActiveController == this.GetComponent<SpotController>())
        MouseOverData.Instance.CurrentlyActiveController = null;
    }

}
