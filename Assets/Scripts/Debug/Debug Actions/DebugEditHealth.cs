using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugEditHealth : DebugAction
{
    public override void Execute()
    {
        FindObjectOfType<ShipController>().health = float.Parse(base.input);
        base.Execute();
    }
}
