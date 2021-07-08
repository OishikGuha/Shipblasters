using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWaveGenerator : MonoBehaviour
{

    public bool start;
    public WaveSpawner waveSpawner;
    public GameObject enemySpawner;
    [Space]
    public int minWaves;
    public int maxWaves = 5;

    public Vector2 minSpawnPosition;
    public Vector2 maxSpawnPosition;
    [Space]
    public bool isRepeating;
    public float repeatDelay;

    // Start is called before the first frame update
    void Awake()
    {
        if(isRepeating)
        StartCoroutine("KeepMakingWaves");

        if(start)
        {
            MakeWave();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator KeepMakingWaves()
    {
        MakeWave();
        yield return new WaitForSeconds(repeatDelay);
        StartCoroutine("KeepMakingWaves");
    }

    public void MakeWave()
    {
        for (int i = 0; i < Random.Range(minWaves, maxWaves); i++)
        {
            GameObject spawner = Instantiate(enemySpawner, new Vector2(Random.Range(minSpawnPosition.x, maxSpawnPosition.x), Random.Range(minSpawnPosition.y, maxSpawnPosition.y)), Quaternion.identity, transform);
            spawner.GetComponent<EnemySpawner>().spawnAtStart = true;
            // spawner.GetComponent<EnemySpawner>().shouldRepeat = true;
            waveSpawner.enemyWaves.Add(new WaveEnemy("Enemy wave " + i, enemySpawner, WaveEnemy.Conditions.noOptions, 0, 0, -1, false));
        }
    }
}
