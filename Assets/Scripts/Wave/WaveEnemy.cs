using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveEnemy
{
    public string waveName;
    public EnemySpawner spawner;
    
    [Space]
    public conditions condition = conditions.enemyDeaths;
    public int seconds;
    public int enemyDeaths;
    public int waveIndex = -1;
    [Space]
    public bool executed;

    public enum conditions
    {
        enemyDeaths,
        timedMode,
        onlyChildMode
    }
}
