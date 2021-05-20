using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CustomizerSelector))]
public class CustomizerSelectorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        CustomizerSelector selector = (CustomizerSelector)target;

        base.OnInspectorGUI();
    }
}
