using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    private InputUser _inputActions;
    private RigidBodeyInteractable _rigidbody;

    private void Start()
    {
         _inputActions =  FindObjectOfType<InputContainer>().InputAction;
        _rigidbody = GetComponent<RigidBodeyInteractable>();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        _rigidbody.MovePosition(transform.position + (Vector3)_inputActions.Player.Move.ReadValue<Vector2>() * _speed * Time.deltaTime);
    }
}