using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformInteractable : MonoBehaviour
{
    public Vector2 Position
    {
        get
        {
            return transform.position;
        }
        set
        {
            SetPosition(value);
        }
    }

    public void Translate(Vector2 movement, Space space = Space.World)
    {
        transform.Translate(movement, space);
    }

    public void Rotation(float z)
    {
        Debug.Log("z - "+ z);
        transform.Rotate(0f, 0f, z);
    }
    private void SetPosition(Vector2 position)
    {
        if (position == null)
            return;
        transform.position = position;
    }



}
