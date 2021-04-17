using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{

    public float speed = 10f;

    public float speedDivisor = 4000f;
    public float turningDivisor = 10f;
    [Space]
    public GameObject bullet;
    public Transform turret;
    [Space]
    public bool ally;
    public float health = 100f;

    float horizontal;
    float vertical;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");        
        vertical = Input.GetAxisRaw("Vertical");        
        Move();

        if(health <=0)
        {
            Die();
        }

        if(Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
    }

    public void Move()
    {
        transform.Rotate(Vector3.forward * -horizontal / turningDivisor);
        transform.Translate(Vector3.up * vertical / speedDivisor * speed, Space.Self);
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public void Shoot()
    {
        var instObj = Instantiate(bullet, transform.position, Quaternion.identity);
        instObj.GetComponent<Bullet>().GetSelfShip(this);
    }
}
