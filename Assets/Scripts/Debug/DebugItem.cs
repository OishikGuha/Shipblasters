using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DebugItem
{
    public string name;
    public DebugAction action;

    public void Init()
    {
        action.actionName = name;
    }
}
