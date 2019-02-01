using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public bool Rotate = true;
    public float speed = 1;
    public Vector3 rotation;

    public void Update()
    {
        if (Rotate && (GameController.Instance == null || !GameController.Instance.Pause))
            this.transform.localEulerAngles += rotation * Time.deltaTime * speed;
    }

}
