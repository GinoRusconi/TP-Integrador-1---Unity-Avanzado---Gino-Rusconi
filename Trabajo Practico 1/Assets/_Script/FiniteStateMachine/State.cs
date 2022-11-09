using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State
{
    protected Entity entity;
    protected FiniteStateMachine finitestateMachine;

    public State(Entity entity, FiniteStateMachine finitestateMachine)
    {
        this.entity = entity;
        this.finitestateMachine = finitestateMachine;
    }

    public abstract void Entry();

    public abstract void LogicUpdate();

    public abstract void PhysicsLogic();

    public abstract void Exit();
    
}
