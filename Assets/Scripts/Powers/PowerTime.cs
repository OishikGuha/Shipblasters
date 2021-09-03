using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PowerTime : MonoBehaviour
{

    public int time;
    public PowerThumbnail thumbnail;
    TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if(time != 0)
        {
            text.text = time.ToString();
            thumbnail.TurnOnImage();
        }
        else
        {
            text.text = "";
            thumbnail.TurnOffImage();
        }
    }
}
