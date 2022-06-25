using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPCStateMachine
{
    public class FallDownState : NPCState<string>
    {
        const string name = "Fall Down";

        NPC npc;

        Vector3 fallLocation;
        float elap;

        public FallDownState(NPCSM<string> _sm, NPC _npc) : base(_sm, name)
        {
            npc = _npc;
        }

        public override void Enter()
        {
            npc.anim.SetFloat("Speed", 0);
            npc.anim.SetTrigger(Animator.StringToHash("FallDown"));

            fallLocation = npc.transform.position - (npc.transform.forward * 3);

            elap = 0f;
        }

        public override void Execute()
        {
            if (elap > 3.4f)
            {
                sm.SetState("Standstill");
            }
            else elap += Time.deltaTime;

            npc.transform.position =
                Vector3.MoveTowards(npc.transform.position, fallLocation, 8 * Time.deltaTime);
        }

        public override void Exit()
        {
            
        }
    }
}