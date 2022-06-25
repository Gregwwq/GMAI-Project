using UnityEngine;

namespace RayWenderlich.Unity.StatePatternInUnity
{
    public class RolLState : State
    {
        int rollParam = Animator.StringToHash("Roll");
        int sheathMeleeParam = Animator.StringToHash("SheathMelee");

        Vector3 targetRollLocation;
        float elap1, elap2;

        public RolLState(Character character, StateMachine stateMachine) : base(character, stateMachine)
        {
        }

        public override void Enter()
        {
            base.Enter();

            character.Rolling = true;

            character.TriggerAnimation(sheathMeleeParam);
            character.TriggerAnimation(rollParam);

            elap1 = elap2 = 0f;
            targetRollLocation = character.transform.position + (character.transform.forward * 8);

            DisplayOnUI(UIManager.Alignment.Left);
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (elap1 > 0.3f)
            {
                character.ColliderSize = character.CrouchColliderHeight;

                Vector3 rollLocation = new Vector3(targetRollLocation.x, character.transform.position.y, targetRollLocation.z);
                
                character.transform.position =
                    Vector3.MoveTowards(character.transform.position, rollLocation, 6 * Time.deltaTime);
            }
            else elap1 += Time.deltaTime;

            if (elap2 > 1.8f)
            {
                stateMachine.ChangeState(character.standing);
            }
            else elap2 += Time.deltaTime;
        }

        public override void PhysicsUpdate()
        {
            base.PhysicsUpdate();
        }

        public override void Exit()
        {
            base.Exit();

            character.Rolling = false;

            character.ColliderSize = character.NormalColliderHeight;
        }
    }
}