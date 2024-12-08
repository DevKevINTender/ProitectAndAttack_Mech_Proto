using UniRx;
using UnityEngine;
using Zenject;

public class UnitView : MonoBehaviour
{
    public HpComponent HpComponent;
    public UnitMoveComponent MoveComponent;
}

public class UnitViewService
{
    [Inject] private IViewFabric _viewFabric;
    [Inject] private IServiceFabric _serviceFabric;
    [Inject] private IEventService _eventService;
    private UnitView _unitView;
    private UnitMoveService _unitMoveViewService;
    private UnitShootViewService _unitShootViewService;
    public void Activate()
    {
        _unitView = _viewFabric.Init<UnitView>();
        _unitView.HpComponent.Activate(1);
        _unitView.HpComponent.DieAction = UnitDie;

        _unitMoveViewService = _serviceFabric.InitSingle<UnitMoveService>();
        _unitMoveViewService.Activate(_unitView.MoveComponent);

        _unitShootViewService = _serviceFabric.InitSingle<UnitShootViewService>();
        _unitShootViewService.Activate(_unitView.transform);
    }

    public void UnitDie()
    {
        _eventService.PublishEvent(new OnLoseSession());
    }
    public void Deactivate()
    {
        _unitMoveViewService.Deactivate();
    }
}

public class UnitMoveService
{
    [Inject] private IViewFabric _viewFabric;
    private PcDirectionPanel _pcDirectionPanel;
    private UnitMoveComponent _unitMoveComponent;
    private UnitMovePointMarker _currentMarker;
    public void Activate(UnitMoveComponent unitMoveComponent)
    {
        _unitMoveComponent = unitMoveComponent;
        _unitMoveComponent.DetectNewUnitMovePointMarkerAction = DetectNewUnitMovePointMarkerAction;
        _pcDirectionPanel = _viewFabric.Init<PcDirectionPanel>();
        _pcDirectionPanel.NewCurrentDirectionAction = NewCurrentDirectionAction;
    }

    private void NewCurrentDirectionAction(Vector3 newDirection)
    {
        if (_currentMarker != null)
        {
            Debug.Log("TEST2");

            if (newDirection == Vector3.right && _currentMarker.E != null) MoveToNewUnitMovePointMarker(_currentMarker.E.transform);
            if (newDirection == Vector3.left && _currentMarker.W != null) MoveToNewUnitMovePointMarker(_currentMarker.W.transform);
            if (newDirection == Vector3.up && _currentMarker.N != null) MoveToNewUnitMovePointMarker(_currentMarker.N.transform);
            if (newDirection == Vector3.down && _currentMarker.S != null) MoveToNewUnitMovePointMarker(_currentMarker.S.transform);
        }
    }

    private void MoveToNewUnitMovePointMarker(Transform pointTargetTrn)
    {
        Debug.Log("TEST3");

        _unitMoveComponent.MoveToPoint(pointTargetTrn);
        _currentMarker = null;
        //когда получать новый маркер. Прямо сейчас нельзя, потому что смогу пргынуть на слеудющий даже не долеев до этого
    }

    private void DetectNewUnitMovePointMarkerAction(UnitMovePointMarker newMarker)
    {
        Debug.Log("TEST4");

        _currentMarker = newMarker;
    }

    public void Deactivate()
    {
    }
}
