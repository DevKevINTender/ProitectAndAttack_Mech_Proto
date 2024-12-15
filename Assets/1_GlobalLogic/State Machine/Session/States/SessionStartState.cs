using Zenject;

public class SessionStartState : IBaseState
{
    [Inject] private SessionScreenService _sessionScreenService;
    [Inject] private LevelService _levelService;
    [Inject] private ChunkViewService _chunkViewService;
    [Inject] private UnitViewService _unitViewService;
    public void Enter()
    {
        _sessionScreenService.Activate();
        _chunkViewService.Activete();
        //_levelService.Activate();
        _unitViewService.Activate();
    }

    public void Exit()
    {
        //_levelService.Deactivate();
        _unitViewService.Deactivate();
        _chunkViewService.Deactivate();
    }

    public void Update()
    {

    }

}
