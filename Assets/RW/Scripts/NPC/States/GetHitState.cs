using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPCStateMachine
{
    public class GetHitState : NPCState<string>
    {
        const string name = "Get Hit";

        NPC npc;

        float elap;

        public GetHitState(NPCSM<string> _sm, NPC _npc) : base(_sm, name)
        {
            npc = _npc;
        }

        public override void Enter()
        {
            npc.anim.SetFloat("Speed", 0);
            npc.anim.SetTrigger(Animator.StringToHash("GetHit"));

            elap = 0f;
        }

        public override void Execute()
        {
            if (elap > 2f)
            {
                sm.SetState("Standstill");
            }
            else elap += Time.deltaTime;
        }

        public override void Exit()
        {
            npc.GetHit = false;
        }
    }
}