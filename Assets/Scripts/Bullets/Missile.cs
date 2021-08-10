using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Bullet
{
    public float minDistanceForTarget;
    public float rotateSpeed = 2f;

    public EnemyShip enemyTarget;

    public override void MoveStart()
    {
        enemyTarget = GetEnemy();
    }

    public override void MoveUpdate()
    {
        if(enemyTarget == null)
        {
            base.ExplodeAndDie();
        }
        else
        {
            FollowTarget(enemyTarget.transform);
        }
    }

    public override void MoveEnemyStart()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(minimumRandomAngle, maximumRandomAngle));
    }

    public override void MoveEnemyUpdate()
    {
        ShipController target = null;

        try
        {
            target = GameManager.FindShipFromCustomizer();            
        }
        catch (System.Exception)
        {
            Debug.Log("trying to find ship...");
        }
        
        FollowTarget(target.transform);
    }

    void FollowTarget(Transform target)
    {
        Vector2 direction =  target.position - transform.position; 
        direction.Normalize();

        float rotationAmount = Vector3.Cross(direction, transform.up).z;
        transform.rotation *= Quaternion.Euler(0, 0, -rotationAmount * rotateSpeed);

        transform.Translate(Vector2.up / speedDivisor * speed, Space.Self);

    }

    EnemyShip GetEnemy()
    {
        EnemyShip enemyTarget = null;

        for (int i = 0; i < EnemyManager._enemies.Count; i++)
        {
            float distance = Vector2.Distance(EnemyManager._enemies[i].transform.position, base.mousePosition);
            if(distance < minDistanceForTarget)
            {
                enemyTarget = EnemyManager._enemies[i];
                break;
            }
            else
            {
                continue;
            }
        }

        if(enemyTarget != null)
        {
            return enemyTarget;
        }
        else
        {
            return null;
        }
    }

}
