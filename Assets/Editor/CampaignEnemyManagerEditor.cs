using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CampaignEnemyManager))]
public class CampaignEnemyManagerEditor : Editor
{

    CampaignEnemyManager manager;

    public override void OnInspectorGUI()
    {
        manager = (CampaignEnemyManager) target;

        base.OnInspectorGUI();
        
        if(GUILayout.Button("Spawn Enemy"))
        {
            manager.Spawn();
        }
    }
}
