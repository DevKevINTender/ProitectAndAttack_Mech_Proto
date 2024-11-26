using System.Collections.Generic;
using System.Linq;
using Zenject;

public class SessionStateMachine 
{
    private IBaseState _currentState;

    private List<IBaseState> _baseStates = new();

    public void SetState<T>() where T : IBaseState
    { 
        _currentState?.Exit();
        _currentState = _baseStates.OfType<T>().FirstOrDefault();
        _currentState.Enter();
    }

    [Inject]
    public void Constructor
    (
        SupportServiceStartState supportServiceStartState,
        SessionStartState testServiceState,
        SessionEndState sessionEndState,
        SessionFinishState sessionFinishState,
        SessionLoseState sessionLoseState
    )
    {
        _baseStates.Add(supportServiceStartState);
        _baseStates.Add(testServiceState);
        _baseStates.Add(sessionEndState);
        _baseStates.Add(sessionFinishState);
        _baseStates.Add(sessionLoseState);
    }

    public void UpdateState()
    {
        _currentState?.Update();
    }
}
