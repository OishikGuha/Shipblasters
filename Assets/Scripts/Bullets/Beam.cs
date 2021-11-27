using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : Bullet
{

    Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
        print(transform.rotation);
        StartCoroutine("DestroyBeam");
    }

    public override void MoveStart()
    {
    }

    public override void MoveUpdate()
    {
        Quaternion rot = transform.parent.rotation;
        transform.rotation = rot;
    }

    public override void MoveEnemyStart()
    {
        
    }

    public override void MoveEnemyUpdate()
    {
        
    }

    public override void DamagePlayer(ShipController shipController)
    {
        shipController.health -= damage;   
    }

    public override void Damage(EnemyShip shipController)
    {
        shipController.health -= damage;
    }

    public override void ToDestroy()
    {
    }

    public override void OnTriggerStay2D(Collider2D other) 
    {
        if(other.tag == "Enemy Ship" && !isEnemy)
        {   
            print("giangoianrogad");
            Instantiate(bulletHitEffect, transform.position, Quaternion.identity);
            EnemyShip shipCtrl = other.GetComponent<EnemyShip>();
            Damage(shipCtrl);
        }
        else if(other.tag == "Ship" && isEnemy)
        {
            Instantiate(bulletHitEffect, transform.position, Quaternion.identity);
            ShipController shipCtrl = other.GetComponent<ShipController>();
            DamagePlayer(shipCtrl);
        }
        else if(other.tag == "ExplosiveBarrel")
        {
            ExplosiveBarrels b = other.GetComponent<ExplosiveBarrels>();    
            b.Explode();
        }
    }

    IEnumerator DestroyBeam()
    {
        print("started!");
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }
}
