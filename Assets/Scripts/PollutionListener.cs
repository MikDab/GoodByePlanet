using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PollutionListener : MonoBehaviour
{

    public GameObject ending;
    public GameObject Main;

    public Slider slider;

    public Polution polution;

    void Awake()
    {
        polution = GameObject.FindObjectOfType<Polution>();
    }

    void Update()
    {
        slider.value = polution.CalculatePolutionPercentage();

        if (slider.value == 100)
        {
            ending.SetActive(true);
            Main.SetActive(false);
        }
    }


}
