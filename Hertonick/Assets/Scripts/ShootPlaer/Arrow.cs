using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObjectInteractable))]
public class Arrow : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Player _player;
    private RigidBodeyInteractable _rigidbody;
    private TransformInteractable _transform;
    private IStateMachine _stateMachine;

    private void Awake()
    {


   
    }

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
    }


    private void Update()
    {
        _stateMachine.Tick();
    }
    public void Flight(Vector2 movement)
    {
        _transform.Position = _player.transform.position;
        _stateMachine.SwitchState<FlightArrowState>();
        _rigidbody.AddForce(movement  *_speed);
    }
}
