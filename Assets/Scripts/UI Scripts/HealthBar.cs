using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public ShipController ship;
    public Gradient gradient;

    Slider slider;

    bool SetMaxVal;

    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        ship = GameManager.FindShipFromCustomizer();

        if(!SetMaxVal)
        {
            slider.maxValue = ship.health;
            SetMaxVal = true;
        }

        slider.value = ship.health;

        Image fillRectImg = slider.fillRect.GetComponent<Image>();
        fillRectImg.color = gradient.Evaluate(slider.normalizedValue);
    }
}
