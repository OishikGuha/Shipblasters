using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampaignMovementUtility
{
    Grid pathfindingGrid;
    float moveDelay;
    Transform obj;
    PathQueueItem pathQueue;

    public CampaignMovementUtility(Grid pathfindingGrid, float moveDelay, Transform obj, PathQueueItem pathQueue)
    {
        this.pathfindingGrid = pathfindingGrid;
        this.moveDelay = moveDelay;
        this.obj = obj;
        this.pathQueue = pathQueue;
    }

    public IEnumerator Move()
    {
        if(pathQueue.completedPath && !pathQueue.completedMoving)
        {
            for (int i = 0; i < pathQueue.path.Count; i++)
            {
                obj.position = pathQueue.path[i].worldPosition;
                
                if(i>0)
                    pathQueue.path.Remove(pathQueue.path[i-1]);
                
                yield return new WaitForSeconds(moveDelay);
            }
            // pathQueue.completedMoving = true;
        }
    
        yield return new WaitForSeconds(moveDelay);
    }
}
