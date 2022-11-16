using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : Life
{
    public Collider _Collider;
    public Animator _Animator;
    protected FiniteStateMachine _FiniteStateMachine;

    protected override void Awake()
    {
        base.Awake();
        _Animator = GetComponentInChildren<Animator>();
        _Collider = GetComponent<Collider>();
        _FiniteStateMachine = new FiniteStateMachine();
    }

    protected override void Update()
    {
        base.Update();
        _FiniteStateMachine.CurrentState.LogicUpdate();
    }

    protected void FixedUpdate()
    {
        _FiniteStateMachine.CurrentState.PhysicsLogic();
    }
}
