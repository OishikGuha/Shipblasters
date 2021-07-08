using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    public Canvas UI;
    [Space]
    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableSettings()
    {
        UI.gameObject.SetActive(true);
    }

    public void DisableSettings()
    {
        UI.gameObject.SetActive(false);
    }

    public void Volume()
    {
        AudioSource[] sources = FindObjectsOfType<AudioSource>();
        if(sources.Length > 0)
        {
            foreach (var item in sources)
            {
                item.volume = volumeSlider.value;
            }
        }
    }
}
