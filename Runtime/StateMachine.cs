using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State[] states;
    public State currentState;
    
    private void Awake()
    {
        foreach (var state in states)
        {
            state.Setup(this);
        }
        
        Initialize(states[0]);
    }

    public void Initialize(State startingState)
    {
        currentState = startingState;
        currentState.EnterState();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            ChangeToNextState();
        }
    }

    public void ChangeToNextState()
    {
        var currentStateIndex = Array.IndexOf(states, currentState);
        
        if (currentStateIndex < states.Length - 1)
        {
            var nextStateIndex = currentStateIndex + 1;
            var nextState = states[nextStateIndex];
            currentState.Exit();
            currentState = nextState;
            currentState.Enter();
        }
        else
        {
            var nextStateIndex = 0;
            var nextState = states[nextStateIndex];
            currentState.Exit();
            currentState = nextState;
            currentState.Enter();
        }
        
    }
    
    public void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }
}
