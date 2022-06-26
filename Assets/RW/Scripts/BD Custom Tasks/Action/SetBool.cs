using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class SetBool : Action
{
    public SharedBool Boolean;
    public bool Intent;

    public override TaskStatus OnUpdate()
    {
        Boolean.Value = Intent;
        return TaskStatus.Success;
    }
}