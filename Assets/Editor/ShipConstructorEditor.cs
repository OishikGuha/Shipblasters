using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ShipConstructor))]
public class ShipConstructorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ShipConstructor shipConstructor = (ShipConstructor)target;

        if(GUILayout.Button("Construct!"))
        {
            shipConstructor.Construct();
        }
    }
}
