    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelGenerator : MonoBehaviour
{

    public GameObject barrel;
    [Space]
    public float size;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Generate()
    {
        float locationX = 0;
        float locationY = 0;

        for (int x = 0; x < size; x++)
        {
            for (int y = 0; y < size; y++)
            {
                locationX = x * distance + Random.Range(-4f,4f);
                locationY = y * distance + Random.Range(-4f,4f);
                
                // if(Physics.BoxCast(new Vector3(x, y, 0), new Vector3(1,2, 0), new Vector3(0f, 0f, 0f)))
                // {
                    Instantiate(barrel, new Vector2(locationX, locationY), Quaternion.identity, transform);
                // }
            }
        }

        // transform.position = new Vector2(-25, -25);
    }
}
