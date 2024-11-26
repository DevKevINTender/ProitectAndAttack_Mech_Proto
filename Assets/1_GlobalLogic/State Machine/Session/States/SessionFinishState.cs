using Zenject;

public class SessionFinishState : IBaseState
{
    [Inject] private FinishPanelService _finishPanelService;
    public void Enter()
    {
        _finishPanelService.Activate();
    }

    public void Exit()
    {
        _finishPanelService.Deactivate();
    }

    public void Update()
    {

    }
}

