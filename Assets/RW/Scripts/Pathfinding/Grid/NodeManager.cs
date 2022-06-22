using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
    public class NodeManager : MonoBehaviour
    {
        public int Width = 40;
        public int Height = 40;
        public float CellSize = 1f;

        PFGrid<Node> grid;

        void Start()
        {
            grid = new PFGrid<Node>(Width, Height);

            for (int x = 0; x < Width - 1; x++)
            {
                for (int y = 0; y < Height - 1; y++)
                {
                    grid.Get(x, y).SetPosition(x, y);
                }
            }
        }

        public Node GetNearestNodeToPosition(Vector3 pos)
        {
            float closestDist = Mathf.Infinity;
            Node closest = null;

            for (int x = 0; x < Width - 1; x++)
            {
                for (int y = 0; y < Height - 1; y++)
                {
                    Node node = grid.Get(x, y);
                    Vector3 nodePos = GetNodeWorldPosition(node);
                    float dist = Vector3.Distance(pos, nodePos);

                    if (dist < closestDist)
                    {
                        closestDist = dist;
                        closest = node;
                    }
                }
            }

            return closest;
        }

        public List<Node> GetNeighbourNodes(Node curr)
        {
            List<Node> list = new List<Node>();

            if (curr.GridX > 0)
            {
                list.Add(grid.Get(curr.GridX - 1, curr.GridY));

                if (curr.GridY > 0) list.Add(grid.Get(curr.GridX - 1, curr.GridY - 1));

                if (curr.GridY < Height - 1) list.Add(grid.Get(curr.GridX - 1, curr.GridY + 1));
            }

            if (curr.GridY > 0)
            {
                list.Add(grid.Get(curr.GridX, curr.GridY - 1));

                if (curr.GridX > 0) list.Add(grid.Get(curr.GridX + 1, curr.GridY - 1));

                if (curr.GridX < Width - 1) list.Add(grid.Get(curr.GridX + 1, curr.GridY + 1));
            }

            if (curr.GridX < Width - 1) list.Add(grid.Get(curr.GridX + 1, curr.GridY));
            
            if (curr.GridY < Height - 1) list.Add(grid.Get(curr.GridX, curr.GridY + 1));
            
            return list;
        }

        public Vector3 GetNodeWorldPosition(Node node)
        {
            return new Vector3(
                transform.position.x + (node.GridX * CellSize),
                transform.position.y,
                transform.position.z + (node.GridY * CellSize)
            );
        }
    }
}
