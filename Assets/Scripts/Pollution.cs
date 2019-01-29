using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollution : MonoBehaviour
{
    [SerializeField] int pollutionCount = 0;
    [SerializeField] int maxPollution = 140;

    [SerializeField][Range(0,1)] float pollutionThreshold;

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
        if (PauseGame.Pause)
            return;

        if (CalculatePollutionPercentage() >= pollutionThreshold)
        {

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
