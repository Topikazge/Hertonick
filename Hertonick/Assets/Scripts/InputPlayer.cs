using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{
    public event Action<Vector3> OnPosition;
    public event Action OnAttack;

    private MovePlayer _movePlayer;

    private void Start()
    {
        _movePlayer = GetComponent<MovePlayer>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            OnAttack();
            return;
        }
        Vector3 movement = new Vector3();
        movement.x = 0;
        movement.y = 0;
        if (Input.GetKey(KeyCode.A))
        {
            movement.x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            movement.x = 1;
        }
        else
        {
            movement.x = 0;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement.y = -1;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            movement.y = 1;
        }
        else
        {
            movement.y = 0;
        }
        OnPosition.Invoke(movement);

      
    }
}
