using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ArrowState : StateBase
{
    protected Arrow _arrow;
    public ArrowState(GameObject gameObject) : base(gameObject)
    {
        _arrow = _gameObjectl.GetComponent<Arrow>();
    }
}
