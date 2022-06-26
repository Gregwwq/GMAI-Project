using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPCStateMachine
{
    public class InteractableState : NPCState<string>
    {
        protected NPC npc;

        public InteractableState(NPCSM<string> _sm, string name, NPC _npc) : base(_sm, name)
        {
            npc = _npc;
        }

        public override void Enter()
        {
            
        }

        public override void Execute()
        {
            if (npc.FallDown) sm.SetState("Fall Down");
            else if (npc.GetHit) sm.SetState("Get Hit");

            if (
                sm.currentState.GetType() == typeof(StandStillState) ||
                sm.currentState.GetType() == typeof(WanderState)
            )
            {
                float dist = Vector3.Distance(npc.transform.position, npc.player.position);

                if (npc.IsPlayerCrouching())
                {
                    if (dist < 4f)
                    {
                        sm.SetState("Chase");
                    }
                }
                else
                {
                    if (dist < 8f)
                    {
                        sm.SetState("Chase");
                    }
                }
            }
        }

        public override void Exit()
        {
           
        }
    }
}