using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiniteStateMachine
{
    State CurrentState;

    public void SetState(State nextState)
    {
        CurrentState.Exit();
        CurrentState = nextState;
        CurrentState.Entry();
    }
}
