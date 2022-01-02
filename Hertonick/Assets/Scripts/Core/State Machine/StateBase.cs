using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBase
{
    protected GameObject _gameObjectl;
    public StateBase(GameObject gameObject)
    {
        _gameObjectl = gameObject;
    }
    public abstract void Start();
    public abstract void Update();
    public abstract void End();
}
