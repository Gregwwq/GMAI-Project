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

        anim.SetFloat("Speed", 0f);

        transform.LookAt(new Vector3(Target.transform.position.x, transform.position.y, Target.transform.position.z));

        anim.SetTrigger(Animator.StringToHash("Shout"));

        elap = 0f;
    }

    public override TaskStatus OnUpdate()
    {
        if (elap > 1.6f) return TaskStatus.Success;
        else elap += Time.deltaTime;

        return TaskStatus.Running;
    }
}