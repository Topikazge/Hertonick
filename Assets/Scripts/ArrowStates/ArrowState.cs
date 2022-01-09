using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArrowState : StateBase
{
    protected Arrow _arrow;
    protected IStateMachine _stateMachine;
    protected Player _player;
    protected RigidBodeyInteractable _rigidbody;
    protected TransformInteractable _transform;
    public ArrowState(GameObject gameObject,Player player) : base(gameObject)
    {
        _arrow = _gameObjectl.GetComponent<Arrow>();
        _stateMachine = _gameObjectl.GetComponent<IStateMachine>();
        _player = player;
        _rigidbody = _gameObjectl.GetComponent<RigidBodeyInteractable>();
        _transform = _gameObjectl.GetComponent<TransformInteractable>();
    }
}
