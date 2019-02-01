using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public static AudioManager Instance { get; private set; }

    public List<SoundObject> AllSounds;
    GameObject Music;
    public GameObject soundPrefab;

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

    public void PlayMusic(bool b) {

        if (Music == null) {

            AudioSource sc = soundPrefab.GetComponent<AudioSource>();
            sc = new AudioSource();
            Music = Instantiate(soundPrefab);

        }

        AudioSource msc = Music.GetComponent<AudioSource>();
        msc.playOnAwake = false;

        if (b)
        {

            SoundObject sound = AllSounds.Find((SoundObject s) => s.Name.Equals("Music"));

            if (sound != null)
            {

                msc.pitch = sound.pitch;
                msc.volume = sound.volume;
                msc.clip = sound.clip;
                msc.loop = sound.loop;

                if (!msc.isPlaying)
                {
                    msc.Play();
                }
            }
            else
            {

                Debug.Log("'music' soundObject not found");

            }
        }
        else {

            msc.Stop();

        }
    }

    public static void ShuffleList<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, list.Count);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public void PlaySound(string name) {

        SoundObject sound = AllSounds.Find((SoundObject s) => s.Name == name);

        ShuffleList(AllSounds);

        if (sound != null)
        {
            soundPrefab.GetComponent<AudioSource>().pitch = sound.pitch;
            soundPrefab.GetComponent<AudioSource>().volume = sound.volume;
            soundPrefab.GetComponent<AudioSource>().clip = sound.clip;
            soundPrefab.GetComponent<AudioSource>().loop = sound.loop;
            soundPrefab.GetComponent<AudioSource>().playOnAwake = true;
            GameObject obj = Instantiate(soundPrefab);

            if (!sound.loop)
            {
                Destroy(obj, sound.clip.length + 0.25f);
            }
        }
        else
        {
            Debug.Log(name + " sound not found.");
        }

    }

}
