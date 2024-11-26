using Newtonsoft.Json;
using System.Collections.Generic;
using UniRx;
using UnityEditor.MPE;
using UnityEngine;
using Zenject;

public class EnemySpawnView: MonoBehaviour
{
    public TargetFinderComponent TargetFinderComponent;
    public List<Transform> SpawnPos = new List<Transform>();
}
public class EnemySpawnViewService
{
    [Inject] private IViewFabric _viewFabric;
    [Inject] private IEventService _eventService;
    [Inject] private IViewServicePoolService _poolsViewService;
    [Inject] private CurrentLevelDataManager _currentLevelDataManager;
    private IViewServicePool _enemyPoolViewService;
    private ReactiveProperty<float> _intervalProperty = new ReactiveProperty<float>(0.1f);
    private CompositeDisposable _disposables = new();
    private EnemySpawnView _enemySpawnView;
    private LevelData _currentLevelData;
    private int _currentSetID = 0;
  
    public void Activate(LevelData CurrentLevelData)
    {
        _currentLevelData = CurrentLevelData;
        _enemyPoolViewService = _poolsViewService.GetPool<EnemyViewService>();
        _enemySpawnView = _viewFabric.Init<EnemySpawnView>();
        _enemySpawnView.TargetFinderComponent.ActivateComponent(typeof(EnemyView));
        _enemySpawnView.TargetFinderComponent.targetCount.Subscribe(value =>
        {
            if (value == 0)
            {
                if (_currentSetID < _currentLevelData.EnemySetsList.Count)
                {
                    SpawnSet(_currentLevelData.EnemySetsList[_currentSetID]);
                }
                else
                {
                    _eventService.PublishEvent(new OnFinishSession());
                }
            }
            else
            {
              
            }

        }).AddTo(_disposables);
    }

    private void SpawnSet(EnemySetData enemySet)
    {

        for (int i = 0; i < enemySet.EnemySet.Length; i++)
        {
            if (enemySet.EnemySet[i].EnemyType != EnemyType.Empty)
            {
                EnemyViewService enemy = (EnemyViewService)_enemyPoolViewService.GetItem();
                enemy.Activate(_enemySpawnView.SpawnPos[i].position, enemySet.EnemySet[i].EnemyType);
            }
        }
        _currentSetID++;
        _currentLevelDataManager.ChangeCurrentSetID(_currentSetID);

    }

    public void Deactivate()
    {
        _enemySpawnView.TargetFinderComponent.DeactivateComponent();
        _disposables.Dispose();
    }
}
