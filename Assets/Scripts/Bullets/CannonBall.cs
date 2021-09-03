using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : Bullet
{

    public Direction dir;

    public enum Direction {right, left};
    public Quaternion rotation;
    Animator animator;
    TrailRenderer trail;

    public override void MoveStart()
    {
        animator = GetComponent<Animator>();
        trail = GetComponent<TrailRenderer>();

        if(dir == Direction.right)
            transform.rotation = Quaternion.Euler(0f,0f,rotation.z - 90);
        else
            transform.rotation = Quaternion.Euler(0f,0f,rotation.z + 90);

    }

    public override void MoveUpdate()
    {    
        transform.Translate(Vector3.up / speedDivisor * speed * Time.deltaTime, Space.Self);
    }

    
    public override void DamagePlayer(ShipController shipController)
    {
        shipController.health -= damage;
        End();
    }

    public void End()
    {
        animator.SetTrigger("End");
    }

    public override void ToDestroy()
    {
        StartCoroutine("DestroyBall");
    }

    IEnumerator DestroyBall()
    {

        yield return new WaitForSeconds(destroyDelay);

        // makes the trail slowly dissapear
        for (int i = 0; i < 5; i++)
        {
            trail.startWidth -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }

        End();
    }
}
