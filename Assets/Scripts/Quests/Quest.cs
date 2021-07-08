using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string questName;
    public QuestConditions questCondition;
    public float value;

    public bool completed;

    public enum QuestConditions
    {
        KillsCheck
    }

    public Quest(string name, QuestConditions condition, float questValue)
    {
        questName = name;
        questCondition = condition;
        value = questValue;
    }
}
