using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugDie : DebugAction
{
    public override void Execute()
    {
        FindObjectOfType<ShipController>().Die();
        base.Execute();
    }
}
