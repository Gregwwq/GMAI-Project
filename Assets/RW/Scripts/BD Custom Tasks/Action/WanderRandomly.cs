using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Pathfinding;

[TaskCategory("Movement")]
public class WanderRandomlyAroundTarget : Action
{
    public SharedTransform target;
    public SharedFloat Speed, RotateSpeed;
    public float WanderRange;

    Animator anim;
    NodeManager nm;
    Pathfinder pf;

    Vector3 targetLocation;
    List<Vector3> path;
    int current = 0;
    float elap;

    public override void OnStart()
    {
        anim = GetComponent<Animator>();
        nm = GameObject.Find("Grid").GetComponent<NodeManager>();
        pf = new Pathfinder(nm);

        SetNewPosition();
        elap = 0;
    }

    public override TaskStatus OnUpdate()
    {
        if (path != null)
        {
            if (current < path.Count)
            {
                targetLocation = path[current];
                Move();
                
                if (Vector3.Distance(transform.position, targetLocation) <= 0.01f) current++;
            }
            else
            {
                anim.SetFloat("Speed", 0f);
                if (elap > 1f)
                {
                    elap = 0f;
                    current = 0;
                    SetNewPosition();
                }
                else elap += Time.deltaTime;
            }
        }

        return TaskStatus.Running;
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

    void SetNewPosition()
    {
        // setting the boundaries of the targt location
        float minX = target.Value.position.x - WanderRange;
        float maxX = target.Value.position.x + WanderRange;
        float minZ = target.Value.position.z - WanderRange;
        float maxZ = target.Value.position.z + WanderRange;

        path = pf.GetPath(
            transform.position,
            new Vector3(
                Random.Range(minX, maxX),
                transform.position.y,
                Random.Range(minZ, maxZ)
            )
        );

        anim.SetFloat("Speed", 0.5f);
    }
}