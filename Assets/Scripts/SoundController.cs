using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public void PlayDefaultMouseSound()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            AudioManager.Instance.PlaySound("MouseClick1");
        }
        if (Input.GetButtonDown("Fire2"))
        {
            AudioManager.Instance.PlaySound("MouseClick2");
        }
    }

    public void PlayPopSound()
    {
        AudioManager.Instance.PlaySound("Pop" + Random.Range(1, 3));
    }
}
