using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class IsBool : Conditional
{
    public SharedBool boolean;

    public override TaskStatus OnUpdate()
    {
        return boolean.Value ? TaskStatus.Success : TaskStatus.Failure;
    }
}