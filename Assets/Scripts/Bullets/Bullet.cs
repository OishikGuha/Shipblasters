using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class  Bullet : MonoBehaviour
{

    public float speed = 10f;
    public float damage = 10f;
    [Space]
    public float speedDivisor = 4000f;
    public bool isEnemy;
    [Space]
    public float minimumRandomAngle;
    public float maximumRandomAngle;
    [Space]
    public float destroyDelay = 2f;
    [Space]
    public GameObject bulletHitEffect;
    public LayerMask playerShieldLayer;

    ShipController selfShip;
    protected Vector2 mousePosition;

    // Start is called before the first frame update
    void Start()    
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(!isEnemy)
        {
            MoveStart();
        }
        else
        {
            transform.tag = "Enemy Bullet";
            gameObject.layer = LayerMask.NameToLayer("Enemy Bullet");
            MoveEnemyStart();
        }
        
        ToDestroy();
    }

    // Update is called once per frame
    void Update()
    {
        if(!isEnemy)
        {
            MoveUpdate();
        }
        else
        {
            MoveEnemyUpdate();
        }
        
    }

    public virtual void Damage(EnemyShip shipController)
    {
        shipController.health -= damage;
        Destroy(gameObject);
    }

    public virtual void DamagePlayer(ShipController shipController)
    {
        shipController.health -= damage;
        Destroy(gameObject);
    }

    public virtual void ToDestroy()
    {
        Destroy(gameObject, destroyDelay);
    }

    public virtual void MoveStart()
    {
        Vector3 diff = mousePosition - (Vector2)transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);        
    }
    
    public virtual void MoveUpdate()
    {
        transform.Translate(Vector3.up / speedDivisor * speed * Time.deltaTime, Space.Self);    
    }

    public virtual void MoveEnemyStart()
    {
        Vector3 diff = GameObject.FindObjectOfType<ShipController>().transform.position - transform.position;
        diff.Normalize();

        transform.LookAt(FindObjectOfType<ShipController>().transform.position, Vector3.up);

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90 + Random.Range(minimumRandomAngle, maximumRandomAngle)); 
    }
    
    public virtual void MoveEnemyUpdate()
    {
        transform.Translate(Vector3.up / speedDivisor * speed * Time.deltaTime, Space.Self);    
    }

    public void GetSelfShip(ShipController PselfShip)
    {
        selfShip = PselfShip;
    }

    public void ExplodeAndDie()
    {
        print("ded");
        Instantiate(bulletHitEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public virtual void OnTriggerStay2D(Collider2D other) 
    {
        // Debug.Log("hit!");
        if(other.tag == "Enemy Ship" && !isEnemy)
        {   
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
            ExplodeAndDie();
        }
    }
}
    