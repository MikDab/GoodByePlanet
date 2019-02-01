using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndYearMonthText : MonoBehaviour
{
    [SerializeField] Text YearMonthText;
    public Color textColor;
    public IntVariable MonthsEndured;
    public IntVariable YearsEndured;

    void OnEnable()
    {
        YearMonthText.text = "<color=#" + ColorUtility.ToHtmlStringRGBA(textColor) + ">" + YearsEndured.Value + "</color> Years & " + "<color=#" + ColorUtility.ToHtmlStringRGBA(textColor) + ">" + MonthsEndured.Value + "</color> Months";
    }

}
