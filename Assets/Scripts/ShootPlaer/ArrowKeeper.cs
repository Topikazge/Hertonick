using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowKeeper : MonoBehaviour
{
    [SerializeField] private Arrow _arrow;
    private bool _isArrowInPlace;

    public bool IsArrowInPlace => _isArrowInPlace;

    public event Action OnPutArrow;
    public event Action OnGetArrow;

    public void PutArrow(Arrow arrow)
    {
        if ((arrow == null) && (_arrow == arrow))
            return;
        _isArrowInPlace = true;
        OnPutArrow?.Invoke();
    }

    public void GetArrow(Action<Arrow> action)
    {
        _isArrowInPlace = false;
        OnGetArrow?.Invoke();
        if (_isArrowInPlace && (action != null))
            action(_arrow);
    }
}