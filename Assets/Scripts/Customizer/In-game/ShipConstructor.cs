using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipConstructor : MonoBehaviour
{

    public ShipScriptableObj shipScriptableObj;
    public bool enemy;

    public GameObject tempLight;
    public float speed;

    public void Construct()
    {
        // Creates the main ship
        GameObject ship = new GameObject(shipScriptableObj.shipName);
        
        ShipController shipController = ship.AddComponent<ShipController>();
        Rigidbody2D shipRb = ship.AddComponent<Rigidbody2D>();
        BoxCollider2D shipBoxCol = ship.AddComponent<BoxCollider2D>();
        SpriteRenderer shipSr = ship.AddComponent<SpriteRenderer>();

        ship.tag = "Ship";
        shipRb.gravityScale = 0;
        shipController.speed = shipScriptableObj.speed;
        
        // configuring the ship's sprite
        shipSr.sprite = shipScriptableObj.shipHull;
        shipSr.sortingLayerName = "Ships";
        shipSr.sortingOrder = 0;

        // creates the turret
        GameObject shipTurret = Instantiate(shipScriptableObj.shipTurret);
        shipTurret.transform.parent = ship.transform;
        // SpriteRenderer turretSr = shipTurret.AddComponent<SpriteRenderer>();
        
        // configuring the turret's sprite
        // turretSr.sprite = shipScriptableObj.shipHull;
        // turretSr.sortingLayerName = "Ships";
        // turretSr.sortingOrder = 10;
                
        // spawns the ship
        Instantiate(tempLight, ship.transform);
    }
}
