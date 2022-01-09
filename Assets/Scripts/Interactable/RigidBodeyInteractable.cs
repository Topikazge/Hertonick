using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodeyInteractable : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    public Vector2 Velocity => _rigidbody.velocity;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    public void MovePosition(Vector3 position)
    {
        _rigidbody.MovePosition(position);
    }

    public void AddForce(Vector2 force)
    {
        _rigidbody.AddForce(force, ForceMode2D.Force);
    }

    public void SetVelocity(Vector2 velocity)
    {
        _rigidbody.velocity = velocity;
    }
    public void SetRotation(float rotation)
    {
        _rigidbody.SetRotation(rotation);
    }
    public void MoveRotation(float angle)
    {
        _rigidbody.MoveRotation(angle);
    }
}
