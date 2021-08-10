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
    public float dashCooldown;
    public bool canDash = true;
    bool canDash2 = true;
    [Header("Shield Settings")]
    public KeyCode shieldKey = KeyCode.E;

    Rigidbody2D rb;
    float horizontal;
    float vertical;
    ShieldScript shield;
    Collider2D col;
    SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        shield = GetComponentInChildren<ShieldScript>();
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");        
        vertical = Input.GetAxis("Vertical");

        Move();
        CancelAngDrag();
        
        // if else hell 
        if(Input.GetKeyDown(shieldKey))
        {
            shield.TurnOn();
        }

        if(Input.GetKeyDown(dashKey))
        {
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
        GameManager.Restart();
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
        if(canDash && canDash2)
        {
            rb.AddForce(dir * dashSpeed);
            canDash = false;
            canDash2 = false;
            StartCoroutine("DashCooldown");
        }
    }

    IEnumerator DashCooldown()
    {
        col.enabled = false;
        sr.color = new Color(255,255,255,0.5f);
        turret.gameObject.SetActive(false);
        yield return new WaitForSeconds(dashCooldown);
        turret.gameObject.SetActive(true);
        col.enabled = true;
        sr.color = new Color(255,255,255,1f);

        canDash = true;
        yield return new WaitForSeconds(dashCooldown);
        canDash2 = true;
    }
}
