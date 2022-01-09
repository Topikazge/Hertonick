using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InPlayerArrowState : ArrowState, IEnter
{
    private GameObjectInteractable _objectInteract;
    private TransformInteractable _transform;
    private Timer _timerEnter;
    private GameObject _objectPlayer;
    private TransformInteractable _transformPlayer;
    private float _force;
    public InPlayerArrowState(GameObject gameObject, Player player) : base(gameObject, player)
    {
        _objectInteract = _gameObjectl.GetComponent<GameObjectInteractable>();
        _transform = _gameObjectl.GetComponent<TransformInteractable>();
        _timerEnter = new Timer(1.5f);
        _timerEnter.OnTimerFinishedEvent += ShotArrow;
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

    public void StartEnter(InputAction.CallbackContext callbackContext)
    {
        _timerEnter.Start();
        _timerEnter.OnTimerFinishedEvent += ShotArrow;
    }

    public void EndEnter(InputAction.CallbackContext callbackContext)
    {
        _force = _timerEnter.GetCurrentTime();
        _timerEnter.Stop();
        ShotCharging();
    }
    private void ShotArrow(float timeEnter)
    {
        _force = timeEnter;
        ShotCharging();
    }

    public void ShotCharging()
    {
        if (_stateMachine.GetCurrentState() is InPlayerArrowState)
        {
            Debug.Log("_stateMachine.GetCurrentState() is IdleArrowState");
            Flight();
        }
    }

    public void Flight()
    {
        //   _transform.Position = _player.transform.position;
        Vector2 vectorr = _player.SightPlayer.SideGaze;
        _stateMachine.SwitchState<FlightArrowState>();
        _transform.Rotation((Mathf.Atan2(vectorr.y, vectorr.x) * Mathf.Rad2Deg) - 90);
        _rigidbody.AddForce(_player.SightPlayer.SideGaze * _arrow.Speed * _force);
/*        Debug.Log("_speed" + _speed);
        Debug.Log("_force" + _force);
        Debug.Log("(_player.SightPlayer.SideGaze" + _player.SightPlayer.SideGaze);*/
    }
}
