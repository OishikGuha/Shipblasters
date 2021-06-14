using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Bullet
{
    public float rotateSpeed = 2f;

    ShipController target;

    public override void MoveEnemyStart()
    {
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(minimumRandomAngle, maximumRandomAngle));
    }

    public override void MoveEnemyUpdate()
    {
        try
        {
            target = GameManager.FindShipFromCustomizer();            
        }
        catch (System.Exception)
        {
            Debug.Log("trying to find ship...");
        }
        
        Vector2 direction =  target.transform.position - transform.position; 
        direction.Normalize();

        float rotationAmount = Vector3.Cross(direction, transform.up).z;
        transform.rotation *= Quaternion.Euler(0, 0, -rotationAmount * rotateSpeed);

        transform.Translate(Vector2.up / speedDivisor * speed, Space.Self);
    }
}
