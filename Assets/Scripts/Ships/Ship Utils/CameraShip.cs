using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShip : MonoBehaviour
{

    public Transform shipTransform;

    bool gottenShip;

    // Update is called once per frame
    void LateUpdate()
    {
        if(!gottenShip)
        {
            shipTransform = FindObjectOfType<ShipController>().transform;
        }

        transform.position = new Vector3(0f,0f,-10f) + shipTransform.position;
    }
}
