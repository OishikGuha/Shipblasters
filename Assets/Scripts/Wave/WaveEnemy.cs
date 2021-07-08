using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WaveEnemy
{
    public string waveName;
    public GameObject spawner;
    
    [Space]
    public Conditions condition = Conditions.enemyDeaths;
    public int seconds;
    public int enemyDeaths;
    public int waveIndex = -1;
    [Space]
    public bool executed;

    public enum Conditions
    {
        enemyDeaths,
        timedMode,
        onlyChildMode,
        noOptions
    }

    public WaveEnemy(string enemyWaveName, GameObject enemySpawner, Conditions enemyConditions, int enemySeconds, int PenemyDeaths, int PwaveIndex, bool Pexecuted)
    {
        waveName = enemyWaveName;
        spawner = enemySpawner;

        condition = enemyConditions;
        seconds = enemySeconds;
        enemyDeaths = PenemyDeaths;
        waveIndex = PwaveIndex;
    }
}
