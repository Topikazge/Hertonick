using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(GameObjectInteractable))]
public class Arrow : MonoBehaviour
{
    [SerializeField] private Quiver _arrowKeeper;
    [SerializeField] private float _speed;
    [SerializeField] private Player _player;
    private RigidBodeyInteractable _rigidbody;
    private TransformInteractable _transform;
    private IStateMachine _stateMachine;
    private Timer _timerEnter;
    private float _force;
    private InputUser _inputActions;
    private void Start()
    {
        _stateMachine = GetComponent<IStateMachine>();
        _stateMachine.Int(new List<StateBase>()
        {new IdleArrowState(gameObject),
        new AttractionArrowState(gameObject),
        new FlightArrowState(gameObject),
        new LiesArrowState(gameObject)});
        _transform = GetComponent<TransformInteractable>();
        _rigidbody = GetComponent<RigidBodeyInteractable>();
        _stateMachine.ReferState<IdleArrowState>().SetTargetMove(_player.gameObject);
        _stateMachine.SetFirstState<IdleArrowState>();



        _inputActions = FindObjectOfType<InputContainer>().InputAction;
        _inputActions.Player.Shot.started += ctx => StartShot(ctx);
        _inputActions.Player.Shot.canceled += ctx => ShotArrow(ctx);

        _timerEnter = new Timer(1.5f);
        _timerEnter.OnTimerFinishedEvent += ShotArrow;
    }


    private void Update()
    {
        _stateMachine.Tick();
    }
    public void Flight()
    {
        _transform.Position = _player.transform.position;
        _stateMachine.SwitchState<FlightArrowState>();
        _rigidbody.AddForce(_player.SightPlayer.SideGaze * _speed * _force);
        Debug.Log("_speed" + _speed);
        Debug.Log("_force" + _force);
        Debug.Log("(_player.SightPlayer.SideGaze" + _player.SightPlayer.SideGaze);
    }



    public void StartShot(InputAction.CallbackContext callbackContext)
    {
        _timerEnter.Start();
        _timerEnter.OnTimerFinishedEvent += ShotArrow;
    }

    private void ShotArrow(InputAction.CallbackContext callbackContext)
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
        if (_stateMachine.GetCurrentState() is IdleArrowState)
        {
            Debug.Log("_stateMachine.GetCurrentState() is IdleArrowState");
            Flight();
        }     
    }

    private void Shot()
    {
    
    }
}
