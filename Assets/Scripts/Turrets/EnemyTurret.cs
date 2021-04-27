using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurret : MonoBehaviour
{

    EnemyShip enemyShip;

    // Start is called before the first frame update
    void Start()
    {
        enemyShip = GetComponentInParent<EnemyShip>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 diff = enemyShip.PlayerShip.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
}
