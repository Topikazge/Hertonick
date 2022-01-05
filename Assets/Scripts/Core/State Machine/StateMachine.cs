using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class StateMachine : MonoBehaviour, IStateMachine
{
    private StateBase _currentState;
    private List<StateBase> _states;

    public void Int(List<StateBase> stateBases)
    {
        if (stateBases == null)
            return;
        _states = stateBases;
    }

    public void SetFirstState<T>() where T : StateBase
    {
        var state = FindState<T>();
        if (state is null)
            return;
        _currentState = state;
    }

    public void SwitchState<T>() where T : StateBase
    {
        var state = FindState<T>();
        if (state is null)
            return;
        _currentState.End();
        state.Start();
        _currentState = state;
    }

    public T ReferState<T>() where T : StateBase
    {
        var state = (T)FindState<T>();
        return state;
    }

    public void Tick()
    {
        _currentState.Update();
    }

    private StateBase FindState<T>() where T : StateBase
    {
        var state = _states.FirstOrDefault(s => s is T);
        if (state == null)
            Debug.LogError("Попытка найти незаданное состояние");
        return state;
    }


}
