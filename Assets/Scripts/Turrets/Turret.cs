using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    
    public GameObject bullet;

    Vector2 mousePos;

    float angle;

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    public virtual void Shoot()
    {
        var instObj = Instantiate(bullet, transform.position, Quaternion.identity);
    }
}
