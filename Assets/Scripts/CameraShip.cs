using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShip : MonoBehaviour
{

    public Transform shipTransform;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0f,0f,-10f) + shipTransform.position;
    }
}
