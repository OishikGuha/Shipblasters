using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject[] enemies;
    public GameObject particle;

    public bool spawnAtStart;
    public bool shouldRepeat;

    public bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        if(spawnAtStart)
        {
            Spawn();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldRepeat)
        {
            spawned = false;
        }
    }

    public void Spawn()
    {
        
        if(!shouldRepeat)
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, Quaternion.identity);

            spawned = true;
        }
    }
}
