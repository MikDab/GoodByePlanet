using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polution : MonoBehaviour
{
    [SerializeField] StringVariable polutionText;
    [SerializeField] int polutionCount = 0;
    [SerializeField] int maxPolution = 178;

    [Range(0,1)]
    public float PollutionThreshold;

    public void IncreasePolution()
    {
        polutionCount++;
        if (polutionText != null)
        {
            UpdatePolutionText();
        }
    }

    public void ReducePolution()
    {
        if (polutionCount > 0)
        {
            polutionCount--;
        }

        if (polutionText != null)
        {
            UpdatePolutionText();
        }
    }

    private void UpdatePolutionText()
    {
        polutionText.Value = CalculatePolutionPercentage() + "% Pollution";
    }

    void Update()
    {
        if (CalculatePolutionPercentage() >= PollutionThreshold)
        {

        }
    }

    public float CalculatePolutionPercentage()
    {
        if (polutionCount > 0)
        {

            float polutionPercentage = (float) polutionCount / maxPolution;
            float mathResult = Mathf.Round(polutionPercentage * 100);
            return mathResult;
        }
        else
        {
            return 0.0f;
        }
    }

    public int GetPolutionCount()
    {
        return polutionCount;
    }

    public int GetMaxPolution()
    {
        return maxPolution;
    }
}
