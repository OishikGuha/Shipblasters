using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public float speed = 10f;
    
    [Space]
    public float speedDivisor = 4000f;
    [Space]
    public GameObject bullet;
    public Transform turret;
    [Space]
    public float health = 100f;
    public float bulletDelay;
    public float bulletDamage = 1f;
    public float accuracy = 20f;
    [Space]
    public float minDistance = 4f;
    [Space]
    public GameObject explosionParticle;

    float horizontal;
    float vertical;

    public Transform PlayerShip;
    float distFromPlayer;

    // Start is called before the first frame update
    void Start()
    {
        PlayerShip = FindObjectOfType<ShipController>().transform;
        StartCoroutine("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        // calculates distance from player
        distFromPlayer = Vector2.Distance(transform.position, PlayerShip.position);

        // rotate
        Rotate();
        
        // checks if health is equal or lesser than 0
        if(health <=0)
        {
            Die();
        }

        // checks if the distance from player is greater than the minimum, if it is it moves.
        if(distFromPlayer > minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, PlayerShip.position, speed * Time.deltaTime);
        }
    }

    void Die()
    {
        Instantiate(explosionParticle, transform.position, Quaternion.identity);
        UIManager.enemiesKilled++;
        Destroy(gameObject);
    }

    void Rotate()
    {
        // rotation stuff that i dont understand
        Vector2 diff = PlayerShip.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }

    IEnumerator Shoot()
    {
        // bullet setup
        var instBullet = Instantiate(bullet, transform.position, Quaternion.identity);
        Bullet instBulletScript = instBullet.GetComponent<Bullet>();
        instBulletScript.maximumRandomAngle = accuracy;
        instBulletScript.minimumRandomAngle = -accuracy;
        instBulletScript.isEnemy = true;
        instBulletScript.damage = bulletDamage;


        yield return new WaitForSeconds(bulletDelay);
        StartCoroutine("Shoot");
    }
}
