using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaiseEventOnEnable : MonoBehaviour
{
    public GameEvent SpawnMoment;

    private void OnEnable()
    {
        SpawnMoment.Raise();
    }
}
