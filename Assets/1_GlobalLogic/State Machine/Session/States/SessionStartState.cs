using Zenject;

public class SessionStartState : IBaseState
{
    [Inject] private LevelService _levelService;
    [Inject] private ShootingService _shootingService;
    [Inject] private UnitViewService _unitViewService;
    public void Enter()
    {
        _levelService.Activate();
        _shootingService.Activate();
        _unitViewService.Activate();
    }

    public void Exit()
    {
        _levelService.Deactivate();
        _shootingService.Deactivate();
        _unitViewService.Deactivate();
    }

    public void Update()
    {

    }

}
