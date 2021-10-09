using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugEditSpeed : DebugAction
{
    public override void Execute()
    {
        FindObjectOfType<ShipController>().speed = float.Parse(base.input);
        base.Execute();
    }
}
