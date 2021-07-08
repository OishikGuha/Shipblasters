using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestsManager : MonoBehaviour
{

    public List<Quest> quests;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < quests.Count; i++)
        {
            if(CheckForKills((int)quests[i].value))
            {
                quests[i].completed = true;
            }
        }
    }

    bool CheckForKills(int kills)
    {
        if(GameManager.enemiesKilled >= kills)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
