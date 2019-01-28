using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogController : MonoBehaviour
{
    private float Offset = 9;
    public float FogChangeSpeed;

    Polution polution;
    int maxPollution;

    private void Start()
    {
        polution = GetComponent<Polution>();
        maxPollution = polution.GetMaxPolution();
    }

    void Update()
    {
        float smogDensity = ((float) polution.GetPolutionCount() / (float) maxPollution) / Offset;

        if (smogDensity > RenderSettings.fogDensity)
        {
            RenderSettings.fogDensity += Time.deltaTime * FogChangeSpeed;
        }
        else if (smogDensity < RenderSettings.fogDensity)
        {
            RenderSettings.fogDensity -= Time.deltaTime * FogChangeSpeed;
        }

        RenderSettings.fogDensity = Mathf.Clamp(RenderSettings.fogDensity, 0f, 1f);
    }
}
