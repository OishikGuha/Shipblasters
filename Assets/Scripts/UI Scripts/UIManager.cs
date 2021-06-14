using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public TextMeshProUGUI enemyHealth;
    public TextMeshProUGUI enemiesKilledText;
    [Space]
    public ShipController ship;
    public EnemyShip enemyShip;

    bool gottenShip;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(!gottenShip)
        {
            ship = FindObjectOfType<ShipController>();
            gottenShip = true;
        }

        enemiesKilledText.text = $"{GameManager.enemiesKilled}";
    }
}
