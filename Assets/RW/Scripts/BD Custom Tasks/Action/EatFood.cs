using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using Pathfinding;

[TaskCategory("Rhino")]
public class EatFood : Action
{
    public SharedInt FoodEaten;

    Animator anim;

    GameObject food;

    float elap1, elap2;

    public override void OnStart()
    {
        anim = GetComponent<Animator>();

        elap1 = elap2 = 0f;

        food = GameObject.FindGameObjectsWithTag("Food")[0];
        transform.LookAt(new Vector3(food.transform.position.x, transform.position.y, food.transform.position.z));

        anim.SetTrigger(Animator.StringToHash("Eat"));
    }

    public override TaskStatus OnUpdate()
    {
        if (elap1 > 3.4f)
        {
            GameObject.Destroy(food);
        }
        else elap1 += Time.deltaTime;

        if (elap2 > 3.6f)
        {
            FoodEaten.Value++;
            return TaskStatus.Success;
        }
        else elap2 += Time.deltaTime;

        return TaskStatus.Running;
    }
}