using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PollutionListener : MonoBehaviour
{

    public GameObject ending;
    public GameObject Main;

    public Slider slider;

    Pollution pollution;

    void Awake()
    {
        pollution = GameObject.FindObjectOfType<Pollution>();
    }

    void Update()
    {
        slider.value = pollution.CalculatePollutionPercentage();

        if (slider.value == 100)
        {
            ending.SetActive(true);
            Main.SetActive(false);
        }
    }


}
