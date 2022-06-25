using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPCStateMachine
{
    public class GetHitState : NPCState<string>
    {
        const string name = "Get Hit";

        NPC npc;

        public GetHitState(NPCSM<string> _sm, NPC _npc) : base(_sm, name)
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