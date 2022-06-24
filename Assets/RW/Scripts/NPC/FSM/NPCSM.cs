using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace NPCStateMachine
{
    public class NPCSM<T>
    {
        Dictionary<T, NPCState<T>> states = new Dictionary<T, NPCState<T>>();
        NPCState<T> currentState = null;

        public NPCSM()
        {

        }

        public void Update()
        {
            if (currentState != null)
            {
                currentState.Execute();
            }
        }

        public void AddState(NPCState<T> state)
        {
            if (state != null)
            {
                states.Add(state.Name, state);
            }
        }
        public void AddState(NPCState<T> state, T name)
        {
            if (state != null)
            {
                states.Add(name, state);
            }
        }

        public void SetState(T name)
        {
            if (currentState != null)
            {
                currentState.Exit();
            }
            currentState = states[name];
            currentState.Enter();
        }
        public void SetState(NPCState<T> nextState)
        {
            if (currentState != null)
            {
                currentState.Exit();
            }
            currentState = nextState;
            currentState.Enter();
        }
    }
}