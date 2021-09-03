using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPowers : MonoBehaviour
{

    public PowerListItem[] powers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FindAndRun(string name, int startTime)
    {
        for (int i = 0; i < powers.Length; i++)
        {
            if(powers[i].name == name)
            {
                powers[i].power.startTime = startTime;
                powers[i].power.StartTimer();
            }
        }
    }
}
