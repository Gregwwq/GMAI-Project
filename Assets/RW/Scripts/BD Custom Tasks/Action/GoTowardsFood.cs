using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Pathfinding;

[TaskCategory("Rhino")]
public class GoTowardsFood : Action
{
    public SharedFloat Speed, RotateSpeed;
    public float ReachRange;

    Animator anim;
    Pathfinder pf;
    NodeManager nm;
    
    Transform food;
    List<Vector3> path;
    Vector3 targetLocation;
    int current;

    public override void OnStart()
    {
        anim = GetComponent<Animator>();
        nm = GameObject.Find("Grid").GetComponent<NodeManager>();
        pf = new Pathfinder(nm);

        anim.SetFloat("Speed", 0.5f);

        GameObject[] foods = GameObject.FindGameObjectsWithTag("Food");
        food = foods[0].transform;

        path = pf.GetPath(transform.position, food.position);
        current = 0;
    }

    public override TaskStatus OnUpdate()
    {
        if (current < path.Count)
        {
            if (Vector3.Distance(transform.position, path[current]) <= 0.01f)
            {
                current++;
            }
            else
            {
                targetLocation = path[current];
                Move();
            }
        }

        if (Vector3.Distance(transform.position, food.transform.position) <= ReachRange) return TaskStatus.Success;
        else return TaskStatus.Running;
    }

    void Move()
    {
        // setting the target rotation
        Quaternion lookRotation = Quaternion.LookRotation((targetLocation - transform.position), Vector3.up);

        // using Vector3.MoveTowards() to move from the current location to the target position
        transform.position =
            Vector3.MoveTowards(transform.position, targetLocation, Speed.Value * Time.deltaTime);

        // using Quaternion.RotateTowards() to smoothly rotate towards the target rotation
        transform.rotation =
            Quaternion.RotateTowards(transform.rotation, lookRotation, RotateSpeed.Value * Time.deltaTime);
    }       
}