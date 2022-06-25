using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPCStateMachine
{
    public class AttackState : InteractableState
    {
        const string name = "Attack";

        public AttackState(NPCSM<string> _sm, NPC npc) : base(_sm, name, npc)
        {
            
        }

        public override void Enter()
        {
            npc.anim.SetFloat("Speed", 0);
            npc.anim.SetTrigger(Animator.StringToHash("Attack"));
        }

        public override void Execute()
        {
            
        }

        public override void Exit()
        {
            
        }
    }
}