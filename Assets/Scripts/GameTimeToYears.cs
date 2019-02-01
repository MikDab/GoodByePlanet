using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimeToYears : MonoBehaviour
{
    GameController gameController;
    float gameTime;
    Text yearsText;
    public IntVariable YearsEndured;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
        yearsText = GetComponent<Text>();
    }

    private void Update()
    {
        gameTime = gameController.GetGameTime();
        UpdateText();
    }

    private void UpdateText()
    {
        yearsText.text = ConvertToYears().ToString();
        YearsEndured.Value = ConvertToYears();
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
