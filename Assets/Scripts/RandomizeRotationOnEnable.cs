using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomizeRotationOnEnable : MonoBehaviour
{
    void OnEnable()
    {
        this.transform.localEulerAngles = new Vector3(0, Random.Range(-180f, 180f), 0);       
    }
}
