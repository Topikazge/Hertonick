using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleArrowState : ArrowState
{
    private GameObjectInteractable _objectInteract;
    private TransformInteractable _transform;

    private GameObject _objectPlayer;
    private TransformInteractable _transformPlayer;
    public IdleArrowState(GameObject gameObject) : base(gameObject)
    {
        _objectInteract = _gameObjectl.GetComponent<GameObjectInteractable>();
        _transform = _gameObjectl.GetComponent<TransformInteractable>();
    }

    public override void End()
    {
        _objectInteract.SetActive(true);
    }

    public override void Start()
    {
        _objectInteract.SetActive(false);
    }

    public override void Update()
    {
        _transform.Position = _transformPlayer.Position;
    }

    public void SetTargetMove(GameObject target)
    {
        if (target == null)
            return;
        _objectPlayer = target;
        _transformPlayer = _objectPlayer.GetComponent<TransformInteractable>();
    }
}
