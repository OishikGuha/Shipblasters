using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExplosiveBarrels : MonoBehaviour
{

    BarrelCollider barrelCollider;

    // Start is called before the first frame update
    void Start()
    {
        barrelCollider = GetComponentInChildren<BarrelCollider>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Ship"))
        {
            // getting stuff
            ShipController ship = col.gameObject.GetComponent<ShipController>();
            Rigidbody2D shipRb = col.gameObject.GetComponent<Rigidbody2D>();
            
            Explode();    

            // destroying stuff
            ship.Damage(30);
        }
        if(col.gameObject.CompareTag("Enemy Ship"))
        {
            // getting stuff
            EnemyShip ship = col.gameObject.GetComponent<EnemyShip>();
            Rigidbody2D shipRb = col.gameObject.GetComponent<Rigidbody2D>();
            
            Explode();    

            // destroying stuff
            ship.Damage(30);
        }
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.CompareTag("Player Projectile"))
        {
            Destroy(col.gameObject);
            Explode();
        }    
    }

    public void Explode()
    {
        
        CameraAnimations.Shake();
        
        // force for the ship
        for (int i = 0; i < barrelCollider.listOfColItems.Count; i++)
        {
            Vector2 diff = barrelCollider.listOfColItems[i].transform.position - gameObject.transform.position;
            Debug.Log(diff);
            barrelCollider.listOfColItems[i].GetComponent<Rigidbody2D>().AddForce(diff.normalized * 5000f * Time.deltaTime);
        }

        AudioManager.Play("Explosion");
        Instantiate(GameManager._explosionParticle, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
