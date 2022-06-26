using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RayWenderlich.Unity.StatePatternInUnity
{
    public class AttackingState : MeleeDrawnState
    {
        int swingMeleeParam = Animator.StringToHash("SwingMelee");

        float elap;

        public AttackingState(Character character, StateMachine stateMachine) : base(character, stateMachine)
        {
        }
        
        public override void Enter()
        {
            base.Enter();

            character.TriggerAnimation(swingMeleeParam);

            if (character.IsInfectedWithinMelee())
            {
                character.AttackInfected();
            }

            elap = 0f;

            DisplayOnUI(UIManager.Alignment.Left);
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (elap > (1.5f))
            {
                stateMachine.ChangeState(character.meleeDrawn);
            }
            else elap += Time.deltaTime;
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