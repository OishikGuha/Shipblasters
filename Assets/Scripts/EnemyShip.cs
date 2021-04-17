using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public float speed = 10f;
    
    [Space]
    public float speedDivisor = 4000f;
    public float turningDivisor = 10f;
    [Space]
    public GameObject bullet;
    public Transform turret;
    [Space]
    public float health = 100f;

    float horizontal;
    float vertical;

    Transform PlayerShip;

    // Start is called before the first frame update
    void Start()
    {
        PlayerShip = FindObjectOfType<ShipController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        // rotation stuff that i dont understand
        Vector2 diff = PlayerShip.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
