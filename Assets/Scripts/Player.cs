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
        Vector2 vector =_inputActions.Player.Move.ReadValue<Vector2>();
        if (vector.x == 0 && vector.y == 0)
            return;
            SightPlayer.SideGaze = vector;
      
    }
}
