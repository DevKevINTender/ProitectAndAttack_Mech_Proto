using Zenject;

public class SessionLoseState : IBaseState
{
    [Inject] private LosePanelService _losePanelService;
    public void Enter()
    {
        _losePanelService.Activate();
    }

    public void Exit()
    {
        _losePanelService.Deactivate();
    }

    public void Update()
    {

    }
}

