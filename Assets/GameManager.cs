using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Tooltip("for development in scene")]public bool spawnPlayerAtStart;
    public GameObject ship;

    public GameObject explosionParticle;
    public static GameObject _explosionParticle;

    public static int enemiesKilled;

    // Start is called before the first frame update
    void Start()
    {

        _explosionParticle = explosionParticle;

        if(spawnPlayerAtStart && ship != null)
        {
            Instantiate(ship);
        }
        else if(spawnPlayerAtStart && ship == null)
        {
            Debug.LogError("Error: Ship is NULL!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static ShipController FindShipFromCustomizer()
    {
        try
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
        catch (System.NullReferenceException)
        {
            Debug.Log("trying to find ship...");
            return null;
        }
    }
}
