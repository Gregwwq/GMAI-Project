using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Rhino")]
public class KnockDownInfected : Action
{
    public SharedBool Tamed;

    Animator anim;
    
    GameObject Target;

    float elap;

    public override void OnStart()
    {
        anim = GetComponent<Animator>();
        Target = GameObject.Find("Infected");

        anim.SetFloat("Speed", 1f);

        anim.SetTrigger(Animator.StringToHash("Attack"));
        Target.GetComponent<NPC>().FallDown = true;
        
        elap = 0f;
    }

    public override TaskStatus OnUpdate()
    {
        if (elap > 1.2f)
        {
            Tamed.Value = false;
            return TaskStatus.Success;
        }
        else elap += Time.deltaTime;

        return TaskStatus.Running;
    }
}