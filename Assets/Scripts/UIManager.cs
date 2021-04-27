using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI health;
    public TextMeshProUGUI enemyHealth;
    [Space]
    public ShipController ship;
    public EnemyShip enemyShip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        health.text = $"HEALTH: {ship.health.ToString()}";
        enemyHealth.text = $"ENEMY HEALTH: {enemyShip.health.ToString()}";
    }
}
