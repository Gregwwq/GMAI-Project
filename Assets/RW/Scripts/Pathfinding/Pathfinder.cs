using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
    public class Pathfinder
    {
        const int StraightMoveCost = 10;
        const int DiagonalMoveCost = 14;

        NodeManager nm;

        List<Node> open, closed;

        public Pathfinder(NodeManager _nm)
        {
            nm = _nm;
        }

        public List<Vector3> GetPath(Vector3 start, Vector3 end)
        {
            List<Vector3> path = new List<Vector3>();

            foreach (Node node in FindPath(
                nm.GetNearestNodeToPosition(start),
                nm.GetNearestNodeToPosition(end)
            ))
            {
                path.Add(nm.GetNodeWorldPosition(node));
            }

            return path;
        }

        List<Node> FindPath(Node start, Node end)
        {
            open = new List<Node>() { start };
            closed = new List<Node>();

            nm.ResetNodes();

            start.G = 0;
            start.H = CalculateMoveCost(start, end);

            while (open.Count > 0)
            {
                Node current = GetLowestFCost();

                if (current == end) return CalculatePath(end);

                open.Remove(current);
                closed.Add(current);

                foreach (Node node in nm.GetNeighbourNodes(current))
                {
                    if (closed.Contains(node)) continue;

                    if (node.Obstacle)
                    {
                        closed.Add(node);
                        continue;
                    }

                    int gCost = current.G + CalculateMoveCost(current, node);
                    if (gCost < node.G)
                    {
                        node.PreviousNode = current;
                        node.G = gCost;
                        node.H = CalculateMoveCost(node, end);

                        if (!open.Contains(node)) open.Add(node);
                    }
                }
            }

            return new List<Node>();
        }

        int CalculateMoveCost(Node a, Node b)
        {
            int x = Mathf.Abs(a.GridX - b.GridX);
            int y = Mathf.Abs(a.GridY - b.GridY);
            int remainder = Mathf.Abs(x - y);

            return (DiagonalMoveCost * Mathf.Min(x, y)) + (StraightMoveCost * remainder);
        }

        Node GetLowestFCost()
        {
            int lowestF = int.MaxValue;
            Node n = null;

            foreach(Node node in open)
            {
                if (node.F < lowestF)
                {
                    lowestF = node.F;
                    n = node;
                }
            }
            
            return n;
        }

        List<Node> CalculatePath(Node end)
        {
            List<Node> path = new List<Node>();
            Node node = end;

            while (node.PreviousNode != null)
            {
                path.Add(node);
                node = node.PreviousNode;
            }

            path.Reverse();
            return path;
        }
    }
}

