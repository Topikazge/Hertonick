using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BowPlayer : MonoBehaviour
{
    private Quiver _arrowKeeper;
    private Player _player;
    private Timer _timerEnter;
    private float _force;
    private void Start()
    {
        _player = GetComponent<Player>();
        _arrowKeeper = GetComponent<Quiver>();
    }

  
}
