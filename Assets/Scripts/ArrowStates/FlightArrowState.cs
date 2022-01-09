using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightArrowState : ArrowState
{
    public FlightArrowState(GameObject gameObject, Player player) : base(gameObject, player)
    {
    }

    public override void End()
    {
        Debug.LogWarning("Метод жизненого цикла state не задан");
    }

    public override void Start()
    {
        Debug.LogWarning("Метод жизненого цикла state не задан");
    }

    public override void Update()
    {
        Vector2 vector2 = _rigidbody.Velocity;
        if ((vector2.x == 0) && (vector2.y == 0))
        {
            _stateMachine.SwitchState<OnPolArrowState>();
            Debug.Log("Меняю");
        }
    }
}
