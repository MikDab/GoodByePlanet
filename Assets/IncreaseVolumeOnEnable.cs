using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseVolumeOnEnable : MonoBehaviour
{
    public float Speed;

    void Awake()
    {
        StartCoroutine(delaySound());
    }

    IEnumerator delaySound()
    {
        AudioListener.volume = 0;
        yield return new WaitForSeconds(0.25f);

        float t = 0;

        while (t <= 1)
        {
            AudioListener.volume = Mathf.Lerp(0f, 1f, t);

            t += Time.deltaTime * Speed;
            yield return null;
        }

        yield return AudioListener.volume = 1f;
    }
}
