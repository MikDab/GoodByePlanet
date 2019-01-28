using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SoundObject", menuName = "Sound Object")]
public class SoundObject : ScriptableObject {

    public string Name;
    public AudioClip clip;
    public float pitch;
    public float volume;
    public bool loop = false;

}
