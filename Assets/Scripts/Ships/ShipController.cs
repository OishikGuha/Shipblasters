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
    [Header("Dash Settings")]
    public KeyCode dashKey;
    public float dashSpeed;
    public float dashDistance;
    public float dashCooldown;
    public bool canDash = true;
    [Header("Shield Settings")]
    public bool isShieldOn;
    public KeyCode shieldKey = KeyCode.E;
    public float shieldCooldown;
    public bool canShield = true;

    Rigidbody2D rb;
    float horizontal;
    float vertical;
    ShieldScript shield;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shield = GetComponentInChildren<ShieldScript>();
    }

    // Update is called once per frame
    void Update()
    {
        shield.isOn = isShieldOn;

        horizontal = Input.GetAxis("Horizontal");        
        vertical = Input.GetAxis("Vertical");

        Move();
        CancelAngDrag();
        
        // if else hell 
        if(Input.GetKeyDown(shieldKey) && canShield)
        {
            StartCoroutine("ShieldCooldown");
            isShieldOn = true;  
        }

        if(Input.GetKeyDown(dashKey))
        {
            Debug.Log("ur such a sussy baka");
            Dash(transform.up.normalized);
        }

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
        Instantiate(GameManager._explosionParticle, transform.position, Quaternion.identity);
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

    public void Dash(Vector2 dir)
    {
        if(canDash)
        {
            Debug.Log(dir);
            rb.AddForce(dir * dashSpeed);
            canDash = false;
            StartCoroutine("DashCooldown");
        }
    }

    IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashCooldown);
        Debug.Log(dashCooldown);
        canDash = true;
    }

    IEnumerator ShieldCooldown()
    {
        yield return new WaitForSeconds(shieldCooldown);
        isShieldOn = false;
    }
}
