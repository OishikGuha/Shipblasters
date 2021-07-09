using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDragger : MonoBehaviour
{

    public float zoomSensitivity;
    [Space]
    public Vector2 minCoords;
    public Vector2 maxCoords;

    Vector3 mousePos;
    Vector3 diff;
    Vector3 origin;
    Vector3 mainDiff;

    bool drag;

    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Drag();
        Zoom();
    }

    public void Drag()
    {
        if(Input.GetMouseButton(1))
        {
            diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            if(!drag)
            {
                drag = true;
                origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            drag = false;
        }

        if(drag)
        {
            mainDiff = (Vector3.forward * -10f) + origin - diff;
            transform.position = mainDiff;
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCoords.x, maxCoords.x), Mathf.Clamp(transform.position.y, minCoords.y, maxCoords.y), -10f);
    }

    public void Zoom()
    {
        float mouseScroll = Input.mouseScrollDelta.y;

        cam.orthographicSize -= mouseScroll;
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, 2, 7);
    }
}
