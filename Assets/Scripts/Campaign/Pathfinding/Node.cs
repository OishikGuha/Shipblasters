using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Node
{
    public int hCost;
    public int gCost;

    public bool walkable;
    public Vector3 worldPosition;

    public int gridX;
    public int gridY;

    public Node parent;

    public Node(bool walkable, Vector3 worldPosition, int gridX, int gridY)
    {
        this.gridX = gridX;
        this.gridY = gridY;

        this.walkable = walkable;
        this.worldPosition = worldPosition;
    }

    public int fCost
    {
        get
        {
            return hCost + gCost;
        }
    }
}
