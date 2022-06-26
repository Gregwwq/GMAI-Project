using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RayWenderlich.Unity.StatePatternInUnity
{
    public class MeleeDrawnState : StandingState
    {
        int sheathMeleeParam = Animator.StringToHash("SheathMelee");

        bool sheathMelee;
        bool swingMelee;

        public MeleeDrawnState(Character character, StateMachine stateMachine) : base(character, stateMachine)
        {
        }
        
        public override void Enter()
        {
            base.Enter();
            
            sheathMelee = false;
            swingMelee = false;

            DisplayOnUI(UIManager.Alignment.Left);
        }

        public override void HandleInput()
        {
            base.HandleInput();

            sheathMelee = Input.GetKeyDown(KeyCode.C);
            swingMelee = Input.GetMouseButtonDown(0);
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (sheathMelee)
            {
                character.TriggerAnimation(sheathMeleeParam);
                stateMachine.ChangeState(character.standing);
            }
            else if (swingMelee && stateMachine.CurrentState.GetType() != typeof(AttackingState))
            {
                stateMachine.ChangeState(character.swingMelee);
            }
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void Exit()
        {
            base.Exit();
        }
    }
}