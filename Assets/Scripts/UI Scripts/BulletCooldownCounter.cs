using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class BulletCooldownCounter : MonoBehaviour
{

    public Turret playerTurret;
    [Space]
    public int seconds;

    Text text;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();

        if(playerTurret.delay >= 1)
        {
            
            playerTurret.whenShot.AddListener(CountDown);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(seconds != 0)
            text.text = seconds.ToString();
        else
            text.text = "";
    }

    void CountDown()
    {
        seconds = (int)playerTurret.delay;

        StartCoroutine("DecrementSecond");           
    }

    IEnumerator DecrementSecond()
    {
        
        yield return new WaitForSeconds(1);
        seconds--;

        if(seconds != 0)
        StartCoroutine("DecrementSecond");

    }
}
