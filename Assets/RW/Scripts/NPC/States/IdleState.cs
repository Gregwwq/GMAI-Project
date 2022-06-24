using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

namespace NPCStateMachine
{
    public class IdleState : NPCState<string>
    {
        const string name = "Idle";

        public IdleState(NPCSM<string> _sm) : base(_sm, name)
        {

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