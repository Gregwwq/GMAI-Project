using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Obstacle : MonoBehaviour
{
    NodeManager nm;

    void Start()
    {
        nm = GameObject.Find("Grid").GetComponent<NodeManager>();
    }

    void Update()
    {
        nm.SetObstacles(transform.position, transform.localScale.x, transform.localScale.z);
    }
}
