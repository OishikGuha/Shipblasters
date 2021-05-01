using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class AudioEffect
{
    public string name;
    public string description;

    [Range(0,1)]
    public float volume;

    [Space]
    public AudioClip audioClip;
}
