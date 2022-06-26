using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPCStateMachine
{
    public class AttackState : InteractableState
    {
        const string name = "Attack";

        float elap;

        public AttackState(NPCSM<string> _sm, NPC npc) : base(_sm, name, npc)
        {
            
        }

        public override void Enter()
        {
            base.Enter();

            npc.anim.SetFloat("Speed", 0);
            npc.anim.SetTrigger(Animator.StringToHash("Attack"));

            elap = 0f;
        }

        public override void Execute()
        {
            base.Execute();

            if (elap > 2.6f)
            {
                sm.SetState("Chase");
            }
            else elap += Time.deltaTime;
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}