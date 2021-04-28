using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI health;
    public TextMeshProUGUI enemyHealth;
    public TextMeshProUGUI enemiesKilledText;
    [Space]
    public ShipController ship;
    public EnemyShip enemyShip;
    public static int enemiesKilled;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health.text = $"HEALTH: {ship.health.ToString()}";
        enemyHealth.text = $"ENEMY HEALTH: {enemyShip.health.ToString()}";
        enemiesKilledText.text = $"ENEMIES KILLED: {enemiesKilled}";
    }
}
