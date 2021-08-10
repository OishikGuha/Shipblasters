using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileTurret : Turret
{

    public MissileTarget target;

    public override void Shoot()
    {
        if(target.targettedEnemy != null && !(target.targettedEnemy.GetComponent<EnemyShip>().health/damage < 0))
        {
            GameObject mis = Instantiate(bullet, transform.position, Quaternion.identity);
            mis.GetComponent<Missile>().enemyTarget = target.targettedEnemy.GetComponent<EnemyShip>();
        }

        base.Recoil(300f);
    }
}
