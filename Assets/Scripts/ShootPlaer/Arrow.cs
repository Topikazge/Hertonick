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

    private TransformInteractable _transform;
    private IStateMachine _stateMachine;

    private InputUser _inputActions;

    public float Speed => _speed;
    private void Start()
    {
        _stateMachine = GetComponent<IStateMachine>();
        _stateMachine.Int(new List<StateBase>()
        {new InPlayerArrowState(gameObject,_player),
        new MagniteArrowState(gameObject,_player),
        new FlightArrowState(gameObject,_player),
        new OnPolArrowState(gameObject,_player)});
        _transform = GetComponent<TransformInteractable>();
        _stateMachine.ReferState<InPlayerArrowState>().SetTargetMove(_player.gameObject);
        _stateMachine.SetFirstState<InPlayerArrowState>();



        _inputActions = FindObjectOfType<InputContainer>().InputAction;
        _inputActions.Player.Shot.started += ctx => StartShot(ctx);
        _inputActions.Player.Shot.canceled += ctx => ShotArrow(ctx);

  
    }


    private void Update()
    {
        _stateMachine.Tick();
    }




    public void StartShot(InputAction.CallbackContext callbackContext)
    {
        IEnter enter = _stateMachine.GetCurrentState() as IEnter;
        if (enter != null)
        {
            enter.StartEnter(callbackContext);
        }
    }

    private void ShotArrow(InputAction.CallbackContext callbackContext)
    {
        IEnter enter = _stateMachine.GetCurrentState() as IEnter;
        if (enter != null)
        {
            enter.EndEnter(callbackContext);
        }
    }

 

    private void Shot()
    {
    
    }
}
