using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    
    public GameObject bullet;
    public bool applyDamageOnBullet; 
    public float damage;
    public float delay = 0.1f;

    Vector2 mousePos;
    public bool canShoot;
    public bool endedCooldown;


    private void Start() 
    {
        canShoot = true;    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        if(Input.GetMouseButtonDown(0) && canShoot)
        {
            Shoot();
            canShoot = false;
            endedCooldown = false;
        }

        if(!canShoot && !endedCooldown)
        {
            endedCooldown = true;
            StartCoroutine("CanShoot");
        }
    }

    public virtual void Shoot()
    {
        var instObj = Instantiate(bullet, transform.position, Quaternion.identity);
        if(applyDamageOnBullet)
        {
            instObj.GetComponent<Bullet>().damage = damage;
        }
    }

    IEnumerator CanShoot()
    {
        yield return new WaitForSeconds(delay);
        Debug.Log("a");
        canShoot = true;
    }
}
