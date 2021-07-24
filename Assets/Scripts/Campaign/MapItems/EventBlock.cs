using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EventBlock : MonoBehaviour
{

    public string eventDesc;
    public Text eventDescText;

    // Update is called once per frame
    void Update()
    {
        eventDescText.text = eventDesc;
    }
}
