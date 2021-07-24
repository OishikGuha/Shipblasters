using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PathQueueItem
{
    public Vector3 startPos;
    public Vector3 targetPos;

    public List<Node> path;

    public bool completedPath = false;
    public bool completedMoving = false;

    public PathQueueItem(Vector3 start, Vector3 target)
    {
        startPos = start;
        targetPos = target;
    }
}
