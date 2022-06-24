using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Rhino")]
public class IsInfectedWithinRange : Conditional
{
    public float Range;

    Transform infected;

    public override void OnStart()
    {
        infected = GameObject.Find("Character").transform;
    }

    public override TaskStatus OnUpdate()
    {
        if (Vector3.Distance(transform.position, infected.position) <= Range)
        {
            return TaskStatus.Success;
        }
        else return TaskStatus.Failure;
    }
}