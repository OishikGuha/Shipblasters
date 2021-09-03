using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerThumbnail : MonoBehaviour
{

    public Image img;

    // Start is called before the first frame update
    void Start()
    {
        img = GetComponent<Image>();
    }

    public void TurnOffImage()
    {
        img.color = new Color(0.2f, 0.2f, 0.2f);
    }

    public void TurnOnImage()
    {
        img.color = new Color(1.0f, 1.0f, 1.0f);
    }
}
