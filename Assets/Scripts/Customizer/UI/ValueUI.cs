using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ValueUI : MonoBehaviour
{

    public CustomizerSelector selector;
    [Space]
    public Text speedText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        speedText.text = selector.speed.ToString("0");
    }
}
