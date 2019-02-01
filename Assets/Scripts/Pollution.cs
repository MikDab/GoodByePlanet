using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollution : MonoBehaviour
{
    [SerializeField] int pollutionCount = 0;
    [SerializeField] int maxPollution = 140;

    [Tooltip("Value in % when pollution should escalate")]
    [SerializeField] [Range(0, 100)] float pollutionThreshold = 0;
    [SerializeField] float thresholdIncrementTime = 5f;

    float thresholdTimer = 0f;

    public void IncreasePollution()
    {
        pollutionCount++;
    }

    public void ReducePollution()
    {
        if (pollutionCount > 0)
        {
            pollutionCount--;
        }
    }

    void Update()
    {
        if (GameController.Instance.Pause)
            return;

        if (CalculatePollutionPercentage() >= pollutionThreshold)
        {
            thresholdTimer += Time.deltaTime;

            if (thresholdTimer >= thresholdIncrementTime)
            {
                IncreasePollution();
                thresholdTimer = 0;
            }
        }
    }

    public float CalculatePollutionPercentage()
    {
        if (pollutionCount > 0)
        {
            float polutionPercentage = (float) pollutionCount / maxPollution;
            float mathResult = Mathf.Round(polutionPercentage * 100);
            return mathResult;
        }
        else
        {
            return 0.0f;
        }
    }

    public int GetPollutionCount()
    {
        return pollutionCount;
    }

    public int GetMaxPollution()
    {
        return maxPollution;
    }
}
