using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePointer : MonoBehaviour
{

    Vector2 mousePos;

    public bool hasClicked;
    public bool isHolding;
    public bool hasReleased;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        transform.position = mousePos;

        // for clicking
        if(Input.GetMouseButtonDown(0))
        {
            hasClicked = true;
        }
        else
        {
            hasClicked = false;
        }
    
        // for releasing
        if(Input.GetMouseButtonUp(0))
        {
            hasReleased = true;
        }
        else
        {
            hasReleased = false;
        }
    
        // for holding
        if(Input.GetMouseButton(0))
        {
            isHolding = true;
        }
        else
        {
            isHolding = false;
        }
    }
}