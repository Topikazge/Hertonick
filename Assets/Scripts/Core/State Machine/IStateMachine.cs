using System.Collections.Generic;

public interface IStateMachine
{
    public void Int(List<StateBase> stateBases);
    public void SetFirstState<T>() where T : StateBase;
    public void SwitchState<T>() where T : StateBase;
    public T ReferState<T>() where T : StateBase;
    public StateBase GetCurrentState();
    public void Tick();
}
