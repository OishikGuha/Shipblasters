using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 10f;
    public float damage = 10f;

    public float speedDivisor = 4000f;
    public bool isEnemy;

    public float minimumRandomAngle;
    public float maximumRandomAngle;

    ShipController selfShip;

    // Start is called before the first frame update
    void Start()
    {
        if(!isEnemy)
        {
            Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            diff.Normalize();

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);    
        }
        else
        {
            Vector3 diff = GameObject.FindObjectOfType<ShipController>().transform.position - transform.position;
            diff.Normalize();

            transform.LookAt(FindObjectOfType<ShipController>().transform.position, Vector3.up);

            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90 + Random.Range(minimumRandomAngle, maximumRandomAngle)); 
        }
        
        Destroy(gameObject, 4);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up / speedDivisor * speed, Space.Self);    
    }

    public void Damage(EnemyShip shipController)
    {
        shipController.health -= damage;
        Debug.Log("hit enemy!");
        Destroy(gameObject);
    }

    public void DamagePlayer(ShipController shipController)
    {
        shipController.health -= damage;
        Debug.Log("hit enemy!");
        Destroy(gameObject);
    }

    public void GetSelfShip(ShipController PselfShip)
    {
        selfShip = PselfShip;
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        // Debug.Log("hit!");
        if(other.tag == "Enemy Ship" && !isEnemy)
        {   
            EnemyShip shipCtrl = other.GetComponent<EnemyShip>();
            Damage(shipCtrl);
        }
        else if(other.tag == "Ship" && isEnemy)
        {
            ShipController shipCtrl = other.GetComponent<ShipController>();
            DamagePlayer(shipCtrl);
        }
    }
}
