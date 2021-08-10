using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockGenerator : MonoBehaviour
{

    public GameObject[] rocks;
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
                locationX = x * distance + Random.Range(-.4f,.4f);
                locationY = y * distance + Random.Range(-.4f,.4f);

                Instantiate(rocks[Random.Range(0, rocks.Length)], new Vector2(locationX, locationY), Quaternion.identity, transform);
            }
        }

        transform.position = new Vector2(-25, -25);
    }
}
