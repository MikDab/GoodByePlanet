using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillController : MonoBehaviour
{
    [SerializeField] int penaltyPoints = 15;
    [SerializeField] int bonusPoints = 20;
    Score score;

    public GameEvent DeselectAllStichijos;

    private void Start()
    {
        score = FindObjectOfType<Score>();
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
                score.ReduceScore(penaltyPoints);
                this.gameObject.SetActive(false);
                break;
            case Stichija.Kometos:
                score.ReduceScore(penaltyPoints);
                this.gameObject.SetActive(false);
                break;
            case Stichija.Viesulas:
                score.ReduceScore(penaltyPoints);
                this.gameObject.SetActive(false);
                break;
            case Stichija.Zaibas:
                score.ReduceScore(penaltyPoints);
                this.gameObject.SetActive(false);
                break;
            default:
                break;
        }

        DeselectAllStichijos.Raise();
    }
}
