using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotsInTrigger : MonoBehaviour
{
    public List<SpotController> SpotsInRange;

    public void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<SpotController>() == null)
            return;

        if (!SpotsInRange.Contains(other.GetComponent<SpotController>()))
        {
            SpotsInRange.Add(other.GetComponent<SpotController>());
        }

    }

    public void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<SpotController>() == null)
            return;

        if (SpotsInRange.Contains(other.GetComponent<SpotController>()))
        {
            SpotsInRange.Remove(other.GetComponent<SpotController>());
        }

    }

}
