using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class isSelected : MonoBehaviour
{
    public Stichija stichija;
    public List<isSelected> Selections;
    public Color SelectedColor;
    public KeyCode SelectionShortcut;
    private Color startColor;

    void Awake()
    {
        startColor = this.GetComponent<Image>().color;
    }

    public void OnClick()
    {
        if (PauseGame.Pause)
            return;

        DeselectAll();
        SelectThis();
    }

    public void DeselectAll()
    {
        foreach (isSelected sel in Selections)
        {
            sel.DeselectThis();
        }
    }

    void SelectThis()
    {
        this.GetComponent<Image>().color = SelectedColor;
        GameController.CurrentlySelectedStichija = stichija;
    }

    public void DeselectThis()
    {
        this.GetComponent<Image>().color = startColor;
        GameController.CurrentlySelectedStichija = Stichija.Nothing;
    }

    void Update()
    {
        if (Input.GetKey(SelectionShortcut))
        {
            OnClick();
        }
    }
}
