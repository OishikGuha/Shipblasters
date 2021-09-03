using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{

    public int startTime;
    public int time;
    public PowerTime powerTime;

    public bool isGoing;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        powerTime.time = time;
    }

    public void StartTimer()
    {
        time = startTime;
        StartCoroutine("Timer");  
    }

    public IEnumerator Timer()
    {
        isGoing = true;
        if(isGoing)
        {
            for (int i = startTime; i <= time; i--)
            {
                if(i > -1)
                    time = i;
                else
                {
                    break;
                }
                
                yield return new WaitForSeconds(1);
            }
            isGoing = false;
        }   
    }
}
