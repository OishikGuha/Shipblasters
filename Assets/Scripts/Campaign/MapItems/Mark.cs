using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mark : MonoBehaviour
{

    public bool gotPlayer;
    public Transform playerPosition;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = FindObjectOfType<MousePointer>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(gotPlayer)
        {
            transform.position = playerPosition.transform.position;
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if(other.tag == "Mouse Pointer")
        {
            if(Input.GetMouseButton(0))
                gotPlayer = true;
            else
                gotPlayer = false;
        }
    }       
}
