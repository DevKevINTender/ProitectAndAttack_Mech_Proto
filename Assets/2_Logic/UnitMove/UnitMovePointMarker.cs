using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class UnitMovePointMarker : Marker
{
    public UnitMovePointMarker N;
    public UnitMovePointMarker S;
    public UnitMovePointMarker E;
    public UnitMovePointMarker W;
}



public class UnitMoveView : MonoBehaviour
{
    public Action<UnitMovePointMarker> DetectNewUnitMovePointMarkerAction;
    private Coroutine _moveCor;
    public void MoveToPoint(Transform pointTargetTrn)
    {
        if (_moveCor != null) StopCoroutine(_moveCor);
        _moveCor = StartCoroutine(MoveCor(pointTargetTrn));
    }
    public IEnumerator MoveCor(Transform pointTargetTrn)
    {

        while (Vector3.Distance(transform.position, pointTargetTrn.position) > 0.1f)
        {
            transform.position = Vector3.Lerp(transform.position, pointTargetTrn.position, Time.deltaTime);
            yield return null;
        }
        transform.position = pointTargetTrn.position;
    }
}

public class UnitMoveViewService
{
    [Inject] private IViewFabric _viewFabric;
    private PcGunDirectionPanel _pcGunDirectionPanel;
    private UnitMoveView _view;
    private UnitMovePointMarker _currentMarker;
    public void Activate()
    {
        _view = _viewFabric.Init<UnitMoveView>();
        _pcGunDirectionPanel = _viewFabric.Init<PcGunDirectionPanel>();
        ReactiveProperty<Vector3> currentDirection = _pcGunDirectionPanel.GetLeftCurrentDirection;

        currentDirection.Subscribe(value => {
            if(_currentMarker != null)
            {
                if (value == Vector3.right & _currentMarker.E != null) MoveToNewUnitMovePointMarker(_currentMarker.E.transform);
                if (value == Vector3.left & _currentMarker.W != null) MoveToNewUnitMovePointMarker(_currentMarker.W.transform);
                if (value == Vector3.up & _currentMarker.N != null) MoveToNewUnitMovePointMarker(_currentMarker.N.transform);
                if (value == Vector3.down & _currentMarker.S != null) MoveToNewUnitMovePointMarker(_currentMarker.S.transform);
            }
        });
    }

    public void MoveToNewUnitMovePointMarker(Transform pointTargetTrn)
    {
        _currentMarker = null;
        _view.MoveToPoint(pointTargetTrn);
        //когда получать новый маркер. Прямо сейчас нельзя, потому что смогу пргынуть на слеудющий даже не долеев до этого
    }

    public void DetectNewUnitMovePointMarkerAction(UnitMovePointMarker newMarker)
    {
        _currentMarker = newMarker;
    }
}