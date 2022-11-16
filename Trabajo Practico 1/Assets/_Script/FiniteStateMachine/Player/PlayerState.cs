using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : State
{
    protected Player player;
    public PlayerState(Entity entity, FiniteStateMachine finitestateMachine) : base(entity, finitestateMachine)
    {
        this.player = (Player)entity;
    }

    public override void Entry()
    {

    }

    public override void Exit()
    {

    }

    public override void LogicUpdate()
    {

    }

    public override void PhysicsLogic()
    {

    }

}
