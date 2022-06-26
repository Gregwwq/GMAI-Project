using UnityEngine;

namespace RayWenderlich.Unity.StatePatternInUnity
{
    public class PlaceFoodState : State
    {
        int placeFoodParam = Animator.StringToHash("PlaceObject");

        public PlaceFoodState(Character character, StateMachine stateMachine) : base(character, stateMachine)
        {
        }

        float elap1, elap2;
        bool placed;

        public override void Enter()
        {
            base.Enter();

            character.TriggerAnimation(placeFoodParam);
            DisplayOnUI(UIManager.Alignment.Left);

            character.ColliderSize = 2f;

            elap1 = elap2 = 0f;
            placed = false;
        }

        public override void HandleInput()
        {
            base.HandleInput();
        }

        public override void LogicUpdate()
        {
            base.LogicUpdate();

            if (elap1 > 0.6f && !placed)
            {
                character.SpawnFood();
                placed = true;
            }
            else elap1 += Time.deltaTime;

            if (elap2 > 1.6f)
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

            character.ColliderSize = character.NormalColliderHeight;
        }
    }
}