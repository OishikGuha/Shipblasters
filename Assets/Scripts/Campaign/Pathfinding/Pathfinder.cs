using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Pathfinder : MonoBehaviour {

	Grid grid;

	void Awake() {
		grid = GetComponent<Grid> ();
	}

	void Update()
	{
		if(grid.pathQueue.Count > 0)
		{
			GoThroughPathQueue();
		}
	}

	public List<Node> FindPath(Vector3 startPos, Vector3 targetPos) {
		Node startNode = grid.NodeFromWorldPoint(startPos);
		Node targetNode = grid.NodeFromWorldPoint(targetPos);

		List<Node> path = new List<Node>();
		if(!targetNode.walkable)
		{

			List<Node> openSet = new List<Node>();
			HashSet<Node> closedSet = new HashSet<Node>();
			openSet.Add(startNode);


			while (openSet.Count > 0) {
				Node node = openSet[0];
				for (int i = 1; i < openSet.Count; i ++) {
					if (openSet[i].fCost < node.fCost || openSet[i].fCost == node.fCost) {
						if (openSet[i].hCost < node.hCost)
							node = openSet[i];
					}
				}
				openSet.Remove(node);
				closedSet.Add(node);

				if (node == targetNode) {

					path = RetracePath(startNode,targetNode);
					return path;
				}

				foreach (Node neighbour in grid.GetNeighbours(node)) {
					if (neighbour.walkable || closedSet.Contains(neighbour)) {
						
						continue;
					}

					int newCostToNeighbour = node.gCost + GetDistance(node, neighbour);
					if (newCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour)) {
						neighbour.gCost = newCostToNeighbour;
						neighbour.hCost = GetDistance(neighbour, targetNode);
						neighbour.parent = node;

						if (!openSet.Contains(neighbour))
							openSet.Add(neighbour);
					}
				}
			}
		}
		return path;
	}

	public void GoThroughPathQueue()
	{
		for (int i = 0; i < grid.pathQueue.Count; i++)
		{
			// if(!grid.pathQueue[i].completedPath 
			
				grid.pathQueue[i].path = FindPath(grid.pathQueue[i].startPos, grid.pathQueue[i].targetPos);
				grid.pathQueue[i].completedPath = true;
			// }
		}
	}

	List<Node> RetracePath(Node startNode, Node endNode) {
		List<Node> path = new List<Node>();
		Node currentNode = endNode;
		while (currentNode != startNode) {
			path.Add(currentNode);
			currentNode = currentNode.parent;
		}
		path.Reverse();

		return path;
	}

	int GetDistance(Node nodeA, Node nodeB) {
		int dstX = Mathf.Abs(nodeA.gridX - nodeB.gridX);
		int dstY = Mathf.Abs(nodeA.gridY - nodeB.gridY);

		if (dstX > dstY)
			return 14*dstY + 10* (dstX-dstY);
		return 14*dstX + 10 * (dstY-dstX);
	}
}