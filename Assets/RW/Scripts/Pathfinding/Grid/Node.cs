using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
    public class Node
    {
        public Node PreviousNode { get; set; }

        public bool Obstacle { get; set; }

        public int GridX { get; private set; }
        public int GridY { get; private set; }

        public int G { get; set; }
        public int H { get; set; }
        public int F { 
            get { return G + H; }
            set {}
        }        

        public Node()
        {
            Obstacle = false;
        }

        public void SetPosition(int x, int y)
        {
            GridX = x;
            GridY = y;
        }

        public void ResetValues()
        {
            PreviousNode = null;
            
            G = int.MaxValue;
            H = 0;
        }
    }
}