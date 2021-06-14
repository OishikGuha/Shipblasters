using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemy;
    public GameObject particle;

    public bool spawnAtStart;
    public bool shouldRepeat;

    bool spawned;

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
        if(!spawned)
        {
            Instantiate(particle, transform.position, Quaternion.identity);
            Instantiate(enemy, transform.position, Quaternion.identity);

            spawned = true;
        }
    }
}
