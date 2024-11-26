using UnityEngine;
using Zenject;

public class UnitView : MonoBehaviour
{
    public HpComponent HpComponent;
}

public class UnitViewService
{
    [Inject] private IViewFabric _viewFabric;
    [Inject] private IEventService _eventService;
    private UnitView _unitView;
    public void Activate()
    {
        _unitView = _viewFabric.Init<UnitView>();
        _unitView.HpComponent.Activate(1);
        _unitView.HpComponent.DieAction = UnitDie;
    }

    public void UnitDie()
    {
        _eventService.PublishEvent(new OnLoseSession());
    }
    public void Deactivate()
    {

    }
}
