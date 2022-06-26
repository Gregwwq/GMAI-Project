using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Rhino")]
public class IsThereFood : Conditional
{
    public override TaskStatus OnUpdate()
    {
        if (GameObject.FindGameObjectsWithTag("Food").Length > 0)
        {
            return TaskStatus.Success;
        }
        else return TaskStatus.Failure;
    }
}