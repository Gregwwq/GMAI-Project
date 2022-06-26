using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Rhino")]
public class FoodEaten : Conditional
{
    public SharedInt eaten;
    public int Requirement;

    public override TaskStatus OnUpdate()
    {
        if (eaten.Value >= Requirement)
        {
            eaten.Value = 0;
            return TaskStatus.Success;
        }
        else return TaskStatus.Failure;
    }
}