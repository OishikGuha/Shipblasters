using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignEnemyManager : MonoBehaviour
{

    public GameObject campaignEnemy;
    public Grid grid;
    [Space]
    public bool autoSpawnEnemies;
    public float autoSpawnDelay;

    // Start is called before the first frame update
    void Start()
    {
        if(autoSpawnEnemies)
        {
            StartCoroutine("AutoSpawn");    
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        Vector2 spawnPoint = ChooseRandomSpawn();
        Instantiate(campaignEnemy, spawnPoint, Quaternion.identity, transform);
    }

    public Vector2 ChooseRandomSpawn()
    {
        Vector2 spawnPoint = new Vector2(0f, 0f);
        bool chosen = false;

        while(!chosen)
        {
            Vector2Int chosenIndex = new Vector2Int(Random.Range(0, grid.grid.GetLength(0)), Random.Range(0, grid.grid.GetLength(1)));
            if(!grid.grid[chosenIndex.x, chosenIndex.y].walkable)
            {
                spawnPoint = grid.grid[chosenIndex.x, chosenIndex.y].worldPosition;
                chosen = true;
            }
        }
        return spawnPoint;
    }

    IEnumerator AutoSpawn()
    {   
        Spawn();
        yield return new WaitForSeconds(autoSpawnDelay);
        StartCoroutine("AutoSpawn");
    }
}
