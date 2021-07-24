using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignEnemy : MonoBehaviour
{

    public Vector2 chosenPoint;
    Grid grid;

    CampaignMovementUtility mover;
    public PathQueueItem pathQueue;

    // Start is called before the first frame update
    void Start()
    {
        grid = FindObjectOfType<Grid>();
        pathQueue = new PathQueueItem(transform.position, chosenPoint);

        mover = new CampaignMovementUtility(grid, 1, transform, pathQueue);
        grid.pathQueue.Add(pathQueue);
    }

    // Update is called once per frame
    void Update()
    {
        pathQueue.startPos = transform.position;
        pathQueue.targetPos = chosenPoint;

        StartCoroutine(mover.Move());
    }
}
