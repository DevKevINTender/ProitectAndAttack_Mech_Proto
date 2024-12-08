using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ChunkView: MonoBehaviour
{
    public List<UnitMovePointMarker> UnitMovePointMarkerList = new();
}

public class ChunkViewService
{
    [Inject] private IViewFabric _viewFabric;
    [Inject] private IServiceFabric _serviceFabric;
    private ChunkView _view;
    private List<UnitMovePointViewService> _unitMovePointViewServices = new();
    public void Activete()
    {
        _view = _viewFabric.Init<ChunkView>();

        foreach (var item in _view.UnitMovePointMarkerList)
        {
            UnitMovePointViewService newPointService = _serviceFabric.InitMultiple<UnitMovePointViewService>();
            newPointService.Activete(item);
            _unitMovePointViewServices.Add(newPointService);
        }
    }
    public void Deactivate()
    {

    }
}