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
    int current = 0;

    void Start()
    {
        nm = GameObject.Find("Grid").GetComponent<NodeManager>();
        pf = new Pathfinder(nm);

        StartCoroutine(Path());
    }

    void Update()
    {
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

    IEnumerator Path()
    {
        for (;;)//int a = 0; a < 1; a++)
        {
            yield return new WaitForSeconds(.5f);
            
            current = 0;
            path = pf.GetPath(transform.position, Target.transform.position);
        }
    }
}
