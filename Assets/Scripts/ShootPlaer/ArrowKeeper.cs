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

    private void Start()
    {
        _isArrowInPlace = true;
    }
    public void PutArrow(Arrow arrow)
    {
        if ((arrow == null) && (_arrow == arrow))
            return;
        _isArrowInPlace = true;
        OnPutArrow?.Invoke();
    }

    public void GetArrow(Action<Arrow> action)
    {
        OnGetArrow?.Invoke();
        if (_isArrowInPlace && (action != null))
        {
            _isArrowInPlace = false;
            action(_arrow);
            _arrow = null;
        }
         
    }
}