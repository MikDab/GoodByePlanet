using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAnimaton : MonoBehaviour, OnLeftClick
{
    public bool tornado;
    public bool lightning;
    public bool rain;

    [SerializeField]
    Animator tornadoAnimator;
    [SerializeField]
    Animator lightningAnimator;
    [SerializeField]
    Animator rainAnimator;

    public void LeftClick()
    {
        if (tornado)
        {
            tornadoAnimator.SetTrigger("Tornado");
        }
        else if (lightning)
        {
            lightningAnimator.SetTrigger("Lightning");
        }
        else if (rain)
        {
            rainAnimator.SetTrigger("Rain");
        }
        else
        {
            tornadoAnimator.ResetTrigger("Tornado");
            lightningAnimator.ResetTrigger("Lightning");
            rainAnimator.ResetTrigger("Rain");
        }

    }

    public void setRain()
    {
        rain = true;
        lightning = false;
        tornado = false;
        LeftClick();
    }

    public void setLightning()
    {
        rain = false;
        lightning = true;
        tornado = false;
        LeftClick();
    }

    public void setTornado()
    {
        rain = false;
        lightning = false;
        tornado = true;
        LeftClick();
    }

}