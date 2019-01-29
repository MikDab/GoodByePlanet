using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PollutionListener : MonoBehaviour
{
    public Slider slider;
    Pollution pollution;
    public GameEvent GameOverEvent;

    void Awake()
    {
        pollution = FindObjectOfType<Pollution>();
    }

    void Update()
    {
        slider.value = pollution.CalculatePollutionPercentage();

        if (slider.value == 100f)
        {
            GameOverEvent.Raise();
        }
    }


}
