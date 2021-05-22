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
    [Space]
    public float minDistance = 4f;
    [Space]
    public GameObject explosionParticle;

    float horizontal;
    float vertical;

    public Transform PlayerShip;
    float distFromPlayer;

    bool gottenPlayer = false;
    
    
    bool shaking;

    // Update is called once per frame
    void Update()
    {
        if(!gottenPlayer)
        {
            PlayerShip = FindObjectOfType<ShipController>().transform;
            gottenPlayer = true;
        }

        // calculates distance from player
        distFromPlayer = Vector2.Distance(transform.position, PlayerShip.position);

        // rotate
        Rotate();
        
        // checks if health is equal or lesser than 0
        if(health <=0)
        {
            Die();
        }

        if(shaking)
        {
            CameraAnimations.Shake();
            Debug.Log("shaking!");
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
        shaking = true;
        AudioManager.Play("Explosion");
        Debug.Log("Dead!");

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
}
