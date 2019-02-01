using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{

    bool musicPlaying = false;

    void Awake()
    {
        if (!PlayerPrefs.HasKey("Music"))
        {
            AudioManager.Instance.PlayMusic(true);
            musicPlaying = true;
        }
    }

    public void DefaultClickSound()
    {
        AudioManager.Instance.PlaySound("MouseClick");
    }

    public void PlayPopSound()
    {
        AudioManager.Instance.PlaySound("Pop");
    }

    public void ToggleMusic()
    {
        musicPlaying = !musicPlaying;
        AudioManager.Instance.PlayMusic(musicPlaying);

        if (musicPlaying)
        {
            if (PlayerPrefs.HasKey("Music"))
            {
                PlayerPrefs.DeleteKey("Music");
            }
        }
        else
        {
            PlayerPrefs.SetString("Music", "Off");
        }
    }
}
