using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCollider : MonoBehaviour
{

    public List<GameObject> listOfColItems;
    public bool hasCollided;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Ship" || other.tag == "Enemy")
        {
            listOfColItems.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.tag == "Ship" || other.tag == "Enemy")
        {
            listOfColItems.Remove(other.gameObject);
        }
    }
}
