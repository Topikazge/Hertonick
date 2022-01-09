using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OnPolArrowState : ArrowState, IEnter
{
    private float _speed;
    public OnPolArrowState(GameObject gameObject, Player player) : base(gameObject, player)
    {
    }

    public override void End()
    {
        Debug.LogWarning("Метод жизненого цикла state не задан");
    }

    public void EndEnter(InputAction.CallbackContext callbackContext)
    {
        _speed = 0f;
    }


    public void StartEnter(InputAction.CallbackContext callbackContext)
    {
        Vector2 vectorr = _player.transform.position;
        _rigidbody.SetRotation((Mathf.Atan2(vectorr.y, vectorr.x) * Mathf.Rad2Deg) - 90);
        _speed = 1f;
    }

    public override void Start()
    {
        Debug.LogWarning("Метод жизненого цикла state не задан");
    }


    public override void Update()
    {
        _rigidbody.MovePosition(_player.transform.position * _speed);
    }
}
