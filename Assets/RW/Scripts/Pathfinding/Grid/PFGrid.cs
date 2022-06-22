using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinding
{
    public class PFGrid<T> where T : new()
    {
        T[,] gridArr;

        public PFGrid(int width, int height)
        {
            gridArr = new T[width, height];

            for (int x = 0; x < gridArr.GetLength(0); x++)
            {
                for (int y = 0; y < gridArr.GetLength(1); y++)
                {
                    gridArr[x, y] = new T();
                }
            }
        }

        public T Get(int x, int y)
        {
            return gridArr[x, y];
        }
    }
}
