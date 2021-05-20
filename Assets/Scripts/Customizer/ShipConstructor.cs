using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipConstructor : MonoBehaviour
{

    public ShipScriptableObj shipScriptableObj;
    public bool enemy;

    public GameObject tempLight;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Construct()
    {
        GameObject ship = new GameObject(shipScriptableObj.shipName);
        
        ShipController shipController = ship.AddComponent<ShipController>();
        Rigidbody2D shipRb = ship.AddComponent<Rigidbody2D>();
        BoxCollider2D shipBoxCol = ship.AddComponent<BoxCollider2D>();
        
        shipRb.gravityScale = 0;

        GameObject shipTurret = Instantiate(shipScriptableObj.shipTurret);
        shipTurret.transform.parent = ship.transform;

        GameObject hull = new GameObject("hull");
        SpriteRenderer turretSr = hull.AddComponent<SpriteRenderer>();

        turretSr.sprite = shipScriptableObj.shipHull;
        turretSr.sortingLayerName = "Ships";

        
        Instantiate(tempLight, ship.transform);
        hull.transform.parent = ship.transform;
    }
}
