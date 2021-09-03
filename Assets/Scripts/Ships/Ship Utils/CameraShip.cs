using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShip : MonoBehaviour
{

    public Transform shipTransform;
    public float speed;

    bool gottenShip;

    // Update is called once per frame
    void LateUpdate()
    {
        if(!gottenShip)
        {
            shipTransform = FindObjectOfType<ShipController>().transform;   
        }

        // transform.position = new Vector3(0f,0f,-10f) + shipTransform.position + transform.parent.position;

        Vector2 move = Vector2.Lerp(transform.position, shipTransform.position, Time.deltaTime * speed);
        transform.position = new Vector3(move.x, move.y, -10f);
    }
}
