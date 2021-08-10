using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizerManager : MonoBehaviour
{

    public GameObject customizerShipTransporter;
    public bool spawned = false;

    void Start() 
    {
        spawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!spawned)
        {
            Instantiate(customizerShipTransporter);        
            spawned = true;
        }
    }
}
