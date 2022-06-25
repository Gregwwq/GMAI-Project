using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPCStateMachine
{
    public class StandStillState : InteractableState
    {
        const string name = "Standstill";

        float elap, wait;

        public StandStillState(NPCSM<string> _sm, NPC npc) : base(_sm, name, npc)
        {

        }

        public override void Enter()
        {
            base.Enter();

            npc.anim.SetFloat("Speed", 0f);
            elap = 0f;
            wait = Random.Range(0.5f, 2f);
        }

        public override void Execute()
        {
            base.Execute();

            if (elap > wait)
            {
                sm.SetState("Wander");
            }
            else elap += Time.deltaTime;
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}