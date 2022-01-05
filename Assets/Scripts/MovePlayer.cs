using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    private InputUser _inputActions;
    private RigidBodeyInteractable _rigidbody;
    private Player _player;

    private void Start()
    {
        _inputActions = FindObjectOfType<InputContainer>().InputAction;
        _rigidbody = GetComponent<RigidBodeyInteractable>();
        _player = GetComponent<Player>();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        _rigidbody.MovePosition(transform.position + (Vector3)_player.SightPlayer.SideGaze * _speed * Time.deltaTime);
    }
}