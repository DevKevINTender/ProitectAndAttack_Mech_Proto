using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelProgressPanel: MonoBehaviour
{
    public Image CurrentProgressFillImage;
    public Image TotalProgressFillImage;
    public void ChangeProgessStatus(float currentValue, float totalValue)
    {
        TotalProgressFillImage.fillAmount = totalValue;
        CurrentProgressFillImage.fillAmount = currentValue;
    }
}
public class LevelProgressPanelService
{
    [Inject] private CurrentLevelDataManager _currentLevelDataManager;
    [Inject] private LevelArrayDataManager _levelArrayDataManager;
    [Inject] private IViewFabric _viewFabric;
    private LevelProgressPanel _levelProgressPanel;
    private CompositeDisposable _compositeDisposable = new();
    private float _maxSetID = 0;
    public void Activate()
    {
        _levelProgressPanel = _viewFabric.Init<LevelProgressPanel>();
        _maxSetID = _levelArrayDataManager.GetCurrentLevel().EnemySetsList.Count;
        _currentLevelDataManager.CurrentSetID.Subscribe(value =>
        {
            float currentId = value;
            float currentValue = currentId / _maxSetID;
            float totalValue = (currentId - 1) / _maxSetID;
            _levelProgressPanel.ChangeProgessStatus(currentValue, totalValue);
        }).AddTo(_compositeDisposable);
    }

    public void Deactivate()
    {
        _compositeDisposable?.Dispose();
    }
}