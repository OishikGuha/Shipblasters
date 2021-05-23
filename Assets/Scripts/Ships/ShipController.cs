using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    public float speed = 10f;
    public float speedDivisor = 4000f;
    public float turningDivisor = 10f;
    [Space]
    public Transform turret;                
    [Space]
    public bool ally;
    public float health = 100f;
    [Space]
    public GameObject explosionParticle;    

    Rigidbody2D rb;
    float horizontal;
    float vertical;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");        
        vertical = Input.GetAxis("Vertical");

        Move();
        CancelAngDrag();

        if(health <=0)
        {
            Die();
        }
    }

    public void Move()
    {
        transform.Rotate(Vector3.forward * -horizontal / turningDivisor);
        transform.Translate(Vector3.up * vertical / speedDivisor * speed, Space.Self);
    }

    public void Die()
    {   
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void Damage(int damage)
    {
        health -= damage;
    }

    void CancelAngDrag()
    {
        if(horizontal != 0 || vertical != 0)
        {
            rb.angularVelocity = 0;            
        }
    }
}
