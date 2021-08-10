using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipConstructor : MonoBehaviour
{

    public ShipScriptableObj shipScriptableObj;
    public bool enemy;

    public GameObject tempLight;
    public GameObject shield;
    public float speed;
    [Tooltip("For reserve")]public float shieldCooldown;

    public void Construct()
    {
        // Creates the main ship
        GameObject ship = new GameObject(shipScriptableObj.shipName);
        
        ShipController shipController = ship.AddComponent<ShipController>();
        Rigidbody2D shipRb = ship.AddComponent<Rigidbody2D>();
        PolygonCollider2D shipCol = ship.AddComponent<PolygonCollider2D>();
        SpriteRenderer shipSr = ship.AddComponent<SpriteRenderer>();

        ship.tag = "Ship";

        // configuring the ship's rigidbody
        shipRb.gravityScale = 0;
        shipRb.drag = 1;

        // configuring the ship's controller
        shipController.speed = shipScriptableObj.speed;
        shipController.turningDivisor = 1;
        shipController.dashKey = KeyCode.Space;
        shipController.dashSpeed = 400;
        shipController.dashCooldown = 1.5f;

        // configuring the ship's sprite
        shipSr.sprite = shipScriptableObj.shipHull;
        shipSr.sortingLayerName = "Ships";
        shipSr.sortingOrder = 0;
        
        // configuring the ships's collider
        List<Vector2> physicsShape = new List<Vector2>();
        shipSr.sprite.GetPhysicsShape(0, physicsShape);
        shipCol.points = physicsShape.ToArray();

        // creates the turret
        GameObject shipTurret = Instantiate(shipScriptableObj.shipTurret);
        shipTurret.transform.SetParent(ship.transform);
        shipController.turret = shipTurret.transform;

        // creates the light
        GameObject light = Instantiate(tempLight);
        light.transform.SetParent(ship.transform);

        // creates the shield
        GameObject shi = Instantiate(shield);
        shi.transform.SetParent(ship.transform);

        Debug.Log("Constructed");

        // SpriteRenderer turretSr = shipTurret.AddComponent<SpriteRenderer>();
        // configuring the turret's sprite
        // turretSr.sprite = shipScriptableObj.shipHull;
        // turretSr.sortingLayerName = "Ships";
        // turretSr.sortingOrder = 10;
                
        // // spawns the ship
        // Instantiate(tempLight, ship.transform);
    }
}
