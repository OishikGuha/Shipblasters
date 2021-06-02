using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ExplosiveBarrels : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

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

            // force for the ship
            Vector2 diff = ship.transform.position - gameObject.transform.position;
            Debug.Log(diff);
            shipRb.AddForce(diff.normalized * 5000f * Time.deltaTime);

            // destroying stuff
            ship.Damage(30);
            Explode();    
        }
    }

    private void OnTriggerEnter2D(Collider2D col) 
    {
        if(col.gameObject.CompareTag("Player Projectile"))
        {
            Debug.Log("epic gamer momento");
            Destroy(col.gameObject);
            Explode();
        }    
    }

    public void Explode()
    {
        Instantiate(GameManager._explosionParticle, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
