using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogController : MonoBehaviour
{
    [SerializeField] float fogChangeSpeed;

    private Pollution pollution;
    private int maxPollution;
    private float offset = 8;

    private void Start()
    {
        pollution = GetComponent<Pollution>();
        maxPollution = pollution.GetMaxPollution();
    }

    void Update()
    {
        if (GameController.Instance.Pause)
            return;

        float smogDensity = ((float) pollution.GetPollutionCount() / (float) maxPollution) / offset;

        if (smogDensity > RenderSettings.fogDensity)
        {
            RenderSettings.fogDensity += Time.deltaTime * fogChangeSpeed;
        }
        else if (smogDensity < RenderSettings.fogDensity)
        {
            RenderSettings.fogDensity -= Time.deltaTime * fogChangeSpeed;
        }

        RenderSettings.fogDensity = Mathf.Clamp(RenderSettings.fogDensity, 0f, 1f);
    }
}
