using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CampaignEventManager : MonoBehaviour
{

    public Canvas canvas;
    public Transform eventOrigin;
    public GameObject eventBlock;
    [Space]
    public string[] events;
    public List<EventBlock> eventBlocks;
    [Space]
    public float spawningDistance;

    bool eventsChanged;
    string[] prevEvents;

    // Start is called before the first frame update
    void Start()
    {
       MakeEvents();
    }

    // Update is called once per frame
    void Update()
    {
        if(prevEvents != events)
        {
            MakeEvents();
        }
    }

    public void MakeEvents()
    {
        prevEvents = events;

        RemoveBlocks();

        for (int i = 0; i < events.Length; i++)
        {
            // i don't know how to make the variable names here

            // spawning and setting the position
            GameObject e = Instantiate(eventBlock);
            e.transform.SetParent(eventOrigin);
            e.transform.position = new Vector2(eventOrigin.position.x, eventOrigin.position.y + (i * -spawningDistance));

            // getting the event block
            EventBlock ew = e.GetComponent<EventBlock>();

            // everything else lol
            ew.eventDesc = events[i];
            eventBlocks.Add(ew);
        } 
    }

    void RemoveBlocks()
    {
        for (int i = 0; i < eventBlocks.Count; i++)
        {
            Destroy(eventBlocks[i].gameObject);
        }       
        eventBlocks.RemoveAll(delegate(EventBlock e){return true;});
    }
}
