using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class NPC : MonoBehaviour
{
    public GameObject Target;
    
    Pathfinder pf;
    NodeManager nm;

    List<Vector3> path;
    int current;

    void Start()
    {
        nm = GameObject.Find("Grid").GetComponent<NodeManager>();
        pf = new Pathfinder(nm);

        current = 0;
    }

    void Update()
    {
        path = pf.GetPath(transform.position, Target.transform.position);

        Move();
    }

    void Move()
    {
        if (path != null)
        {
            if (current < path.Count)
            {
                transform.position = Vector3.MoveTowards(transform.position, path[current], 3 * Time.deltaTime);
                if (Vector3.Distance(transform.position, path[current]) <= 0.01f) current++;
            }
            else
            {
                path = null;
                current = 0;
            }
        }
    }
}
