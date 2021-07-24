using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampaignUI : MonoBehaviour
{

    public CampaignPlayer player;
    [Space]
    public Text gold;
    public Text health;
    public Text speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // gold.text = player.gold.ToString();
        // health.text = player.health.ToString();
        // speed.text = player.speed.ToString();
    }
}
