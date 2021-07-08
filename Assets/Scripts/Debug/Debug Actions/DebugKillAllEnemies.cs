using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugKillAllEnemies : DebugAction
{
    public override void Execute()
    {
        base.Execute();
        foreach (EnemyShip ship in EnemyManager._enemies)
        {
            ship.Die();
        }
    }
}
