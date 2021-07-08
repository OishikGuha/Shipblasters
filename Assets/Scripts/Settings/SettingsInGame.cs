using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsInGame : MonoBehaviour
{

    public Settings settings;

    // Start is called before the first frame update
    void Start()
    {
        settings = FindObjectOfType<Settings>();
        DontDestroyOnLoad(gameObject);        
    }

    // Update is called once per frame
    void Update()
    {
        if(settings != null)
        {
            settings.Volume();
        }
    }
}
