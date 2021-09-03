using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class AudioManager : MonoBehaviour
{

    public List<AudioEffect> audioEffectsInspector;
    public static List<AudioEffect> audioEffects;

    // pretty much the variable of this gameobject
    static GameObject audioManager;

    // Start is called before the first frame update
    void Start()
    {
        audioManager = gameObject;
        audioEffects = audioEffectsInspector;

        AudioManager.Play("BlackHoleSound");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void Play(string name)
    {
        foreach (AudioEffect audioEffect in audioEffects)
        {
            if(audioEffect.name == name)
            {
                AudioSource audioSource = audioManager.AddComponent<AudioSource>();
                audioSource.clip = audioEffect.audioClip;
                audioSource.volume = audioEffect.volume;

                audioSource.Play();

                audioManager.GetComponent<AudioManager>().DestroyAudioSource(audioSource);
            }
        }
    }

    public void DestroyAudioSource(AudioSource source)
    {
        StartCoroutine("DestroyAudioSourceCoroutine", source);
    }

    IEnumerator DestroyAudioSourceCoroutine(AudioSource source)
    {
        yield return new WaitForSeconds(source.clip.length);
        Destroy(source);
    }
}
