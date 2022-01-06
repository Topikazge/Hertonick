using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BowPlayer : MonoBehaviour
{
    private Quiver _arrowKeeper;
    private Player _player;
    private InputUser _inputActions;
    private Timer _timerEnter;
    private float _force;
    private void Start()
    {
        _player = GetComponent<Player>();
        _arrowKeeper = GetComponent<Quiver>();

        _inputActions = FindObjectOfType<InputContainer>().InputAction;
        _inputActions.Player.Shot.started += ctx => StartShot(ctx);
        _inputActions.Player.Shot.canceled += ctx => ShotArrow(ctx);

        _timerEnter = new Timer(1.5f);
        _timerEnter.OnTimerFinishedEvent += ShotArrow;
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
        _arrowKeeper.GetArrow(Shot);
    }

    private void Shot(Arrow arrow)
    {
        Debug.Log("_force - -" + _force);
        arrow.Flight(_player.SightPlayer.SideGaze, _force);
        _force = 0f;
    }
}
