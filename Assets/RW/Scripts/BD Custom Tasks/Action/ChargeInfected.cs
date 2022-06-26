using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

[TaskCategory("Rhino")]
public class ChargeInfected : Action
{
    public SharedFloat Speed, RotateSpeed;

    Animator anim;

    GameObject Target;

    public override void OnStart()
    {
        anim = GetComponent<Animator>();
        Target = GameObject.Find("Infected");

        anim.SetFloat("Speed", 1f);
    }

    public override TaskStatus OnUpdate()
    {
        if (Vector3.Distance(transform.position, Target.transform.position) <= 1.5f) return TaskStatus.Success;

        Move();

        return TaskStatus.Running;
    }

    void Move()
    {
        // setting the target rotation
        Quaternion lookRotation = Quaternion.LookRotation((Target.transform.position - transform.position), Vector3.up);

        // using Vector3.MoveTowards() to move from the current location to the target position
        transform.position =
            Vector3.MoveTowards(transform.position, Target.transform.position, Speed.Value * Time.deltaTime);

        // using Quaternion.RotateTowards() to smoothly rotate towards the target rotation
        transform.rotation =
            Quaternion.RotateTowards(transform.rotation, lookRotation, RotateSpeed.Value * Time.deltaTime);
    }
}