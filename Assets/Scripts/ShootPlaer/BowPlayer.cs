using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BowPlayer : MonoBehaviour
{
    private ArrowKeeper _arrowKeeper;
    private Player _player;
    private InputUser _inputActions;
    private void Start()
    {
        _player = GetComponent<Player>();
        _arrowKeeper = GetComponent<ArrowKeeper>();

        _inputActions = FindObjectOfType<InputContainer>().InputAction;
        _inputActions.Player.Shot.started += ctx => StartShot(ctx);
        _inputActions.Player.Shot.canceled += ctx => StartShot(ctx);
    }

    public void StartShot(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("ьссссссср акърэ 1 ");
        _arrowKeeper.GetArrow(ShootArrow);
    }

    public void ShotCharging()
    {

    }

    private void ShootArrow(Arrow arrow)
    {
        Debug.Log("ьссссссср акърэ 2 ");
        arrow.Flight(_player.SideGaze);
    }
}
