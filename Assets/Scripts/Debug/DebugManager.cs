using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugManager : MonoBehaviour
{

    public List<DebugItem> debugItems;
    public GameObject debugUI;

    public bool debugIsOpen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Event e = Event.current;

        if(Input.GetKeyDown(KeyCode.ScrollLock))
        {
            debugIsOpen = !debugIsOpen;
        }

        if(debugIsOpen)
        {
            debugUI.SetActive(true);
        }
        else
        {
            debugUI.SetActive(false);
        }
    }

    public void Execute(string itemName)
    {
        for (int i = 0; i < debugItems.Count; i++)
        {
            if(itemName == debugItems[i].name) { debugItems[i].action.Execute(); }
        }
    }
}
