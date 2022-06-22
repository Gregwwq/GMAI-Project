using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class NPC : MonoBehaviour
{
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
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                if (hit.transform.gameObject.name == "Ground")
                {
                    path = pf.GetPath(transform.position, hit.transform.position);
                }
            }
        }
    }

    void Move()
    {
        if (path != null)
        {
            if (current < path.Count)
            {
                transform.Translate(path[current]);
                if (Vector3.Distance(transform.position, path[current]) <= 0)
                current++;
            }
            else
            {
                path = null;
                current = 0;
            }
        }
    }
}
