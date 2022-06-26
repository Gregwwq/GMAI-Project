using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPCStateMachine
{
    public class ChaseState : InteractableState
    {
        const string name = "Chase";

        List<Vector3> path;

        public ChaseState(NPCSM<string> _sm, NPC npc) : base(_sm, name, npc)
        {

        }

        public override void Enter()
        {
            base.Enter();

            npc.anim.SetFloat("Speed", 1);
        }

        public override void Execute()
        {
            base.Execute();

            float dist = Vector3.Distance(npc.transform.position, npc.player.position);

            if (dist < 1.5f)
            {
                sm.SetState("Attack");
            }

            path = npc.pf.GetPath(npc.transform.position, npc.player.position);

            if (path.Count > 0)
            {
                // setting the target rotation
                Quaternion lookRotation = Quaternion.LookRotation((path[0] - npc.transform.position), Vector3.up);

                // using Vector3.MoveTowards() to move from the current location to the target position
                npc.transform.position =
                    Vector3.MoveTowards(npc.transform.position, path[0], npc.ChaseSpeed * Time.deltaTime);

                // using Quaternion.RotateTowards() to smoothly rotate towards the target rotation
                npc.transform.rotation =
                    Quaternion.RotateTowards(npc.transform.rotation, lookRotation, npc.RotationSpeed * Time.deltaTime);
            }
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}