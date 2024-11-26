using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class FinishPanel : MonoBehaviour
{
    public Button ToNextLevel;
    public TMP_Text NextLevelText;
    public Button ToMenu;
    public void Activate(
        Action ToMenuAction,
        Action ToNextLevelAction,
        int NextLevelID)
    {
        gameObject.SetActive(true);
        ToNextLevel.onClick.AddListener(()=> { ToNextLevelAction?.Invoke(); });
        ToMenu.onClick.AddListener(()=> { ToMenuAction?.Invoke(); });
        NextLevelText.text = $"{NextLevelID} : Level";
    }
    public void Deactivate()
    {
        gameObject.SetActive(false);
        
    }
}

public class FinishPanelService
{
    [Inject] private IEventService _eventService;
    [Inject] private IViewFabric _viewFabric;
    [Inject] private LevelArrayDataManager _levelArrayDataManager;
    private FinishPanel _finishPanel;
    public void Activate()
    {
        
        _finishPanel = _viewFabric.Init<FinishPanel>();
        _finishPanel.Activate(
            ToMenuAction,
            ToNextLevelAction,
            _levelArrayDataManager.GetNextLevelID());
    }

    public void ToMenuAction()
    {
        _eventService.PublishEvent(new OnToMenu());
    }

    public void ToNextLevelAction()
    {
        _levelArrayDataManager.UpdateNextLevel();
        _eventService.PublishEvent(new OnNextLevel());
    }

    public void Deactivate()
    {

    }
}
