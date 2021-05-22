using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static ShipController FindShipFromCustomizer()
    {
        bool gottenShip = false;
        if(!gottenShip)
        {
            ShipController ship = FindObjectOfType<ShipController>();
            gottenShip = true;

            return ship;
        }
        else
        {
            Debug.LogError("Error: Cannot Find Ship!");
            return null;
        }
    }
}
