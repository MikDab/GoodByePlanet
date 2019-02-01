using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulse : MonoBehaviour
{
    public bool PulseEnabled;
    public float minScale, maxScale;
    public float speed;

    private float curSpeed;

    // Start is called before the first frame update
    void Start()
    {
        curSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (PulseEnabled)
        {
            if (transform.localScale.x > maxScale)
            {
                curSpeed *= -1;
                transform.localScale = new Vector3(maxScale, maxScale, maxScale);
            }
            else if (transform.localScale.x < minScale)
            {
                curSpeed *= -1;
                transform.localScale = new Vector3(minScale, minScale, minScale);
            }

            transform.localScale = new Vector3(transform.localScale.x + curSpeed * Time.deltaTime, transform.localScale.y + curSpeed * Time.deltaTime, transform.localScale.z + curSpeed * Time.deltaTime);

        }
    }
}
