using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public SightPlayer SightPlayer { get; private set; }
    private InputUser _inputActions;

    private void Awake()
    {
        SightPlayer = new SightPlayer();
        _inputActions = FindObjectOfType<InputContainer>().InputAction;
    }

    private void Update()
    {
        SideUpdate();
    }

    private void SideUpdate()
    {
        SightPlayer.SideGaze = _inputActions.Player.Move.ReadValue<Vector2>();
    }
}
