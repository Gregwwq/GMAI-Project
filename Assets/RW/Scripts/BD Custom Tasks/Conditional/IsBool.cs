using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class IsBool : Conditional
{
    public SharedBool Boolean;

    public override TaskStatus OnUpdate()
    {
        return Boolean.Value ? TaskStatus.Success : TaskStatus.Failure;
    }
}