using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignPlayer : MonoBehaviour
{

    public Grid pathfindingGrid;
    public Pathfinder pathfinder;

    public float moveDelay;
    public Vector2 mousePos;

    public float gold;
    public float health;

    bool isMoving;
    MousePointer mousePointer;
    Vector2 chosenPoint;
    SpriteRenderer sr;

    CampaignMovementUtility mover;
    PathQueueItem queueItem;

    // Start is called before the first frame update
    void Start()
    {
        queueItem = new PathQueueItem(transform.position, chosenPoint);
        pathfindingGrid.pathQueue.Add(queueItem);
        mover = new CampaignMovementUtility(pathfindingGrid, moveDelay, transform, queueItem);

        mousePointer = FindObjectOfType<MousePointer>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        if(Input.GetMouseButtonDown(0))
        {
            chosenPoint = mousePointer.transform.position;
            isMoving = true;
        }

        if(isMoving)
        {
            queueItem.startPos = transform.position;
            queueItem.targetPos = chosenPoint;

            StartCoroutine(mover.Move());
        }

        if((new Vector2(transform.position.x, transform.position.y) - chosenPoint).x < 0f)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
