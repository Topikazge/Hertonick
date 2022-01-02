using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 SideGaze { get; private set; }

    private void Start()
    {
        GetComponent<InputPlayer>().OnPosition += GetSideGaze;
    }

    private void GetSideGaze(Vector3 sideGaze)
    {
        SideGaze = sideGaze;
    }
}
