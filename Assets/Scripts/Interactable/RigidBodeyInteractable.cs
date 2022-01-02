using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodeyInteractable : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }
    public void MovePosition(Vector3 position)
    {
        _rigidbody.MovePosition(position);
    }
    public void MoveRotation(float angle)
    {
        _rigidbody.MoveRotation(angle);
    }
    public void AddForce(Vector2 force)
    {
        _rigidbody.AddForce(force);
    }

}
