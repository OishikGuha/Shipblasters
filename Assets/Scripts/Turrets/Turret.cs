using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Turret : MonoBehaviour
{
    
    public GameObject bullet;
    public bool applyDamageOnBullet; 
    public float damage;
    public float delay = 0.1f;

    Vector2 mousePos;
    public bool canShoot;
    public bool endedCooldown;
    public bool shot;

    public bool hasParent;

    // this event is for cooldowns
    public UnityEvent whenShot;

    ShipController ship;

    private void Start() 
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        StartFacing();

        if(Input.GetMouseButtonDown(0) && canShoot)
        {
            Shoot();
            whenShot.Invoke();
            canShoot = false;
            endedCooldown = false;  
            shot = true;
        }

        if(!canShoot && !endedCooldown)
        {
            endedCooldown = true;
            StartCoroutine("CanShoot");
            shot = false;
        }
    }

    public void StartFacing()
    {
        // random math shit
        Vector3 diff = mousePos - (Vector2)transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
        // the end of random math shit
    }

    public virtual void Shoot()
    {
        var instObj = Instantiate(bullet, transform.position, Quaternion.identity);
        var instObjBullet = instObj.GetComponent<Bullet>();
        
        instObjBullet.tag = "Player Projectile";    
        if(applyDamageOnBullet)
        {
            instObjBullet.damage = damage;
        }

        // Debug.Log(mouse position: " + mousePos);

        Vector2 diff = (Vector2)transform.position - mousePos;
        

        ship = GetShipParent();
        Rigidbody2D shipRb = ship.GetComponent<Rigidbody2D>();

        shipRb.AddForce(diff * 500f * Time.deltaTime);
    }

    public ShipController GetShipParent()
    {
        if(hasParent)
        {
            return transform.parent.parent.GetComponent<ShipController>();
        }
        else
        {
            return transform.parent.GetComponent<ShipController>();
        }
    }

    IEnumerator CanShoot()
    {
        yield return new WaitForSeconds(delay);
        canShoot = true;
    }
}
