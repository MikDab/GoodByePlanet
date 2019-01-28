using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimeToMonths : MonoBehaviour
{
    GameController gameController;
    float gameTime;
    Text monthsText;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        monthsText = GetComponent<Text>();
    }

    private void Update()
    {
        gameTime = gameController.GetGameTime();
        UpdateText();
    }

    private void UpdateText()
    {
        monthsText.text = ConvertToMonths().ToString();
    }

    public int ConvertToYears()
    {
        return Mathf.FloorToInt(gameTime * 1.8f);
    }

    public int ConvertToMonths()
    {
        return Mathf.FloorToInt(gameTime * 1.8f * 12);
    }
}
