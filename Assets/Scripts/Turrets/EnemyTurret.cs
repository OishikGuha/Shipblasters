using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{

    public GameObject bullet;
    public GameObject bulletHitEffect;
    public bool applyDamageOnBullet; 
    public float bulletDamage = 1f;
    [Space]
    public float bulletDelay;
    public float accuracy = 20f;

    EnemyShip enemyShip; 

    // Start is called before the first frame update
    void Start()
    {
        enemyShip = GetComponentInParent<EnemyShip>();
        StartCoroutine("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 diff = enemyShip.PlayerShip.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    IEnumerator Shoot()
    {
        // bullet setup
        var instBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        Bullet instBulletScript = instBullet.GetComponent<Bullet>();
        instBulletScript.bulletHitEffect = bulletHitEffect;
        instBulletScript.maximumRandomAngle = accuracy;
        instBulletScript.minimumRandomAngle = -accuracy;
        instBulletScript.isEnemy = true;
        
        if(applyDamageOnBullet)
            instBulletScript.damage = bulletDamage;


        yield return new WaitForSeconds(bulletDelay);
        StartCoroutine("Shoot");
    }
}
