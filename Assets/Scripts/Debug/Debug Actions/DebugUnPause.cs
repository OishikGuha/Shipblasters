using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugUnPause : DebugAction
{
    public override void Execute()
    {
        Time.timeScale = 1;
        base.Execute();
    }
}
