using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Rhino")]
public class IsPlayerWithinRange : Conditional
{
    public float Range;

    Transform player;

    public override void OnStart()
    {
        player = GameObject.Find("Character").transform;
    }

    public override TaskStatus OnUpdate()
    {
        if (Vector3.Distance(transform.position, player.position) <= Range)
        {
            return TaskStatus.Success;
        }
        else return TaskStatus.Failure;
    }
}