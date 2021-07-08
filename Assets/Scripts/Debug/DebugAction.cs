using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugAction : MonoBehaviour
{

    public string actionName;

    public virtual void Execute()
    {
        Debug.Log("executed debug action");
    }
}
