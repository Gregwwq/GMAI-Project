using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPCStateMachine
{
    public class DieState : NPCState<string>
    {
        const string name = "Die";

        NPC npc;

        public DieState(NPCSM<string> _sm, NPC _npc) : base(_sm, name)
        {
           npc = _npc;
        }

        public override void Enter()
        {
            npc.anim.SetTrigger(Animator.StringToHash("Die"));
            npc.enabled = false;
        }

        public override void Execute()
        {

        }

        public override void Exit()
        {

        }
    }
}