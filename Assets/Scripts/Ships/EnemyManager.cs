using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{

    public List<EnemyShip> enemies = new List<EnemyShip>();
    public static List<EnemyShip> _enemies = new List<EnemyShip>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemies = FindObjectsOfType<EnemyShip>().ToList();
        _enemies = enemies;
    }
}
