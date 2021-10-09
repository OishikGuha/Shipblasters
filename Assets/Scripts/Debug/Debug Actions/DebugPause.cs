using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugPause : DebugAction
{
    public override void Execute()
    {
        Time.timeScale = 0;
        base.Execute();
    }
}
