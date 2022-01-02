using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    [SerializeField] private float _speed;
    private RigidBodeyInteractable _rigidbody;

    private void Start()
    {
        GetComponent<InputPlayer>().OnPosition += Move;
        _rigidbody = GetComponent<RigidBodeyInteractable>();
    }

    public void Move(Vector3 movement)
    {
        _rigidbody.MovePosition(transform.position + movement * _speed * Time.deltaTime);
    }
}