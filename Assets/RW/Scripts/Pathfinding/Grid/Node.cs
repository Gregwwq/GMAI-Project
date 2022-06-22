using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
    public class Node
    {
        public Node PreviousNode { get; set; }

        public int G { get; set; }
        public int H { get; set; }
        public int F { 
            get { return G + H; }
            set {}
        }

        public int GridX { get; private set; }
        public int GridY { get; private set; }

        public Node()
        {
            PreviousNode = null;
            
            G = int.MaxValue;
            H = 0;
        }

        public void SetPosition(int x, int y)
        {
            GridX = x;
            GridY = y;
        }
    }
}