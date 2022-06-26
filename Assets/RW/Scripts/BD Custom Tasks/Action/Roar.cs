using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Rhino")]
public class Roar : Action
{
    Animator anim;
    
    GameObject Target;

    float elap;

    public override void OnStart()
    {
        anim = GetComponent<Animator>();
        Target = GameObject.Find("Infected");
        
        anim.SetTrigger(Animator.StringToHash("Shout"));

        transform.LookAt(new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z));

        elap = 0f;
    }

    public override TaskStatus OnUpdate()
    {
        if (elap > 2f) return TaskStatus.Success;
        else elap += Time.deltaTime;

        return TaskStatus.Running;
    }
}