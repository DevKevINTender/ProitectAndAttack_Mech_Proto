using UnityEngine;
using Zenject;

public class LevelService
{
    [Inject] private IServiceFabric _serviceFabric;
    [Inject] private LevelArrayDataManager _levelArrayDataManager;
    private EnemySpawnViewService _enemySpawnViewService;
    public void Activate()
    {
        LevelData currentLevel = _levelArrayDataManager.GetCurrentLevel();
        _enemySpawnViewService = _serviceFabric.InitSingle<EnemySpawnViewService>();
        _enemySpawnViewService.Activate(currentLevel);
    }
    public void Deactivate()
    {
        _enemySpawnViewService?.Deactivate();
    }
}