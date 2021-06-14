using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public List<WaveEnemy> enemyWaves; 
    public WaveEnemy waveEnemy;
    public float time;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time = Time.time;

        for (int i = 0; i < enemyWaves.Count; i++)
        {
            if(enemyWaves[i].condition == WaveEnemy.conditions.timedMode)
            {
                Debug.Log("halal habibi");
                if(CheckForTime(enemyWaves[i]))
                {
                    ExecuteWave(enemyWaves[i]);
                }
            }
            
            if(enemyWaves[i].condition == WaveEnemy.conditions.enemyDeaths)
            {
                if(CheckForKills(enemyWaves[i]))
                {
                    ExecuteWave(enemyWaves[i]);
                }
            }
            
            if(enemyWaves[i].condition == WaveEnemy.conditions.onlyChildMode)
            {
                ExecuteWave(enemyWaves[i]);    
            }
        }
    }

    public void ExecuteWave(WaveEnemy wave)
    {
        wave.spawner.Spawn();
        wave.executed = true;
        if(wave.waveIndex > -1)
        {
            ExecuteWave(enemyWaves[wave.waveIndex]);
        }
    }

    public bool CheckForTime(WaveEnemy wave)
    {
        if(time > wave.seconds)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool CheckForKills(WaveEnemy wave)
    {
        if(GameManager.enemiesKilled >= wave.enemyDeaths)
        {
            Debug.Log("ooga booga");
            return true;
        }
        else
        {
            return false;
        }
    }
}
