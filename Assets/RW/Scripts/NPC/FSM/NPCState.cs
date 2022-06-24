using UnityEngine;

namespace NPCStateMachine
{
    public abstract class NPCState<T>
    {
        public readonly T Name;

        protected NPCSM<T> sm;

        public NPCState(NPCSM<T> _sm, T _name)
        {
            sm = _sm;
            Name = _name;
        }

        public virtual void Enter() { }
        public virtual void Execute() { }
        public virtual void Exit() { }
    }
}