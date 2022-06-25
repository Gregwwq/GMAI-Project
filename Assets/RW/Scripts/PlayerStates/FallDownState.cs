using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPCStateMachine
{
    public class FallDownState : NPCState<string>
    {
        const string name = "Fall Down";

        NPC npc;

        public FallDownState(NPCSM<string> _sm, NPC _npc) : base(_sm, name)
        {
            npc = _npc;
        }

        public override void Enter()
        {
            
        }

        public override void Execute()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}