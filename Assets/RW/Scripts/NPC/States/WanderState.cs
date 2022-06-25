using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPCStateMachine
{
    public class WanderState : InteractableState
    {
        const string name = "Wander";

        List<Vector3> path;
        Vector3 targetLocation;
        int current;

        public WanderState(NPCSM<string> _sm, NPC npc) : base(_sm, name, npc)
        {
            
        }

        public override void Enter()
        {
            base.Enter();

            current = 0;
            SetPath();
            npc.anim.SetFloat("Speed", 0.5f);
        }

        public override void Execute()
        {
            base.Execute();

            if (current < path.Count)
            {
                targetLocation = path[current];
                Move();

                if (Vector3.Distance(npc.transform.position, targetLocation) <= 0.01f) current++;
            }
            else
            {
                sm.SetState("Standstill");
            }
        }

        public override void Exit()
        {
            base.Exit();
        }

        void Move()
        {
            // setting the target rotation
            Quaternion lookRotation = Quaternion.LookRotation((targetLocation - npc.transform.position), Vector3.up);

            // using Vector3.MoveTowards() to move from the current location to the target position
            npc.transform.position =
                Vector3.MoveTowards(npc.transform.position, targetLocation, npc.Speed * Time.deltaTime);

            // using Quaternion.RotateTowards() to smoothly rotate towards the target rotation
            npc.transform.rotation =
                Quaternion.RotateTowards(npc.transform.rotation, lookRotation, npc.RotationSpeed * Time.deltaTime);
        }

        void SetPath()
        {
            float minX = npc.transform.position.x - 6f;
            float maxX = npc.transform.position.x + 6f;
            float minZ = npc.transform.position.z - 6f;
            float maxZ = npc.transform.position.z + 6f;

            path = npc.pf.GetPath(
                npc.transform.position,
                new Vector3(
                    Random.Range(minX, maxX),
                    npc.transform.position.y,
                    Random.Range(minZ, maxZ)
                )
            );
        }
    }
}