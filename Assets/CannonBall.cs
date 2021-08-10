using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : Bullet
{

    public Direction dir;

    public enum Direction {right, left};
    public Quaternion rotation;

    public override void MoveStart()
    {
        if(dir == Direction.right)
            transform.rotation = Quaternion.Euler(0f,0f,rotation.z - 90);
        else
            transform.rotation = Quaternion.Euler(0f,0f,rotation.z + 90);

    }

    public override void MoveUpdate()
    {    
        transform.Translate(Vector3.up / speedDivisor * speed * Time.deltaTime, Space.Self);
    }
}
