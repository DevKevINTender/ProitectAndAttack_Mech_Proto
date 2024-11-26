using Zenject;

public class LevelService
{
    [Inject] private IServiceFabric _serviceFabric;
    [Inject] private LevelArrayDataManager _levelArrayDataManager;
    private EnemySpawnViewService _enemySpawnViewService;
    private LevelProgressPanelService _levelProgressPanelService;
    public void Activate()
    {
        LevelData currentLevel = _levelArrayDataManager.GetCurrentLevel();
        _enemySpawnViewService = _serviceFabric.InitSingle<EnemySpawnViewService>();
        _enemySpawnViewService.Activate(currentLevel);

        _levelProgressPanelService = _serviceFabric.InitSingle<LevelProgressPanelService>();
        _levelProgressPanelService.Activate();
    }
    public void Deactivate()
    {
        _enemySpawnViewService?.Deactivate();
        _levelProgressPanelService?.Deactivate();
    }
}

