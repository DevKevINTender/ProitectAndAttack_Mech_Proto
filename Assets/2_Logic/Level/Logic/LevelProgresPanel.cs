using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LevelProgressPanel: MonoBehaviour
{
    public Image CurrentProgressFillImage;

    private float _currentValue;
    private Coroutine _progressFillProcessCor;

    public void ChangeProgessStatus(float newCurrentValue)
    {
        if(_progressFillProcessCor != null) StopCoroutine(_progressFillProcessCor);
        _progressFillProcessCor = StartCoroutine(ProgressFillProcess(newCurrentValue));
    }
    private IEnumerator ProgressFillProcess(float newCurrentValue)
    {
        while (_currentValue != newCurrentValue)
        {          
            _currentValue = Mathf.Lerp(_currentValue, newCurrentValue, 1f * Time.deltaTime);
            CurrentProgressFillImage.fillAmount = _currentValue;
            yield return null;
        }
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
        _maxSetID = _levelArrayDataManager.GetCurrentLevel().EnemySetsList.Count - 1;
        _currentLevelDataManager.CurrentSetID.Subscribe(value =>
        {
            float currentId = value;
            float currentValue = (currentId -1) / _maxSetID;
            _levelProgressPanel.ChangeProgessStatus(currentValue);
        }).AddTo(_compositeDisposable);
    }

    public void Deactivate()
    {
        _compositeDisposable?.Dispose();
    }
}