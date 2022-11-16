using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateIdle : PlayerState
{
    public PlayerStateIdle(Entity entity, FiniteStateMachine finitestateMachine) : base(entity, finitestateMachine)
    {
    }

    public override void Entry()
    {
        base.Entry();
    }

    public override void Exit()
    {

    }

    public override void LogicUpdate()
    {
        
    }

    public override void PhysicsLogic()
    {
        base.PhysicsLogic();

        if (player.inputHandler.directionMove != Vector3.zero)
        {
            player.transform.Translate(player.inputHandler.directionMove * Time.deltaTime * player.stats.movementVelocity);
        }
        else
        {
            finitestateMachine.SetState(new PlayerStateRun(entity, finitestateMachine));
        }
    }

}
