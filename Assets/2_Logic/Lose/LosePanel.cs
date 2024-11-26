using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LosePanel : MonoBehaviour
{
    public Button Restart;
    public TMP_Text CurrentLevelText;
    public Button ToMenu;
    public void Activate(
        Action ToMenuAction,
        Action RestartAction,
        int CurrentLevelID)
    {
        gameObject.SetActive(true);
        Restart.onClick.AddListener(() => { RestartAction?.Invoke(); });
        ToMenu.onClick.AddListener(() => { ToMenuAction?.Invoke(); });
        CurrentLevelText.text = $"{CurrentLevelID} : Level";
    }
    public void Deactivate()
    {
        gameObject.SetActive(false);

    }
}

public class LosePanelService
{
    [Inject] private IEventService _eventService;
    [Inject] private IViewFabric _viewFabric;
    [Inject] private LevelArrayDataManager _levelArrayDataManager;
    private LosePanel _losePanel;
    public void Activate()
    {

        _losePanel = _viewFabric.Init<LosePanel>();
        _losePanel.Activate(
            ToMenuAction,
            RestartAction,
            _levelArrayDataManager.GetNextLevelID());
    }

    public void ToMenuAction()
    {
        _eventService.PublishEvent(new OnToMenu());
    }

    public void RestartAction()
    {
        _eventService.PublishEvent(new OnRestartLevel());
    }

    public void Deactivate()
    {

    }
}

