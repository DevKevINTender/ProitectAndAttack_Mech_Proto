using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShootingService
{
    [Inject] private IViewFabric _viewFabric;
    [Inject] private IServiceFabric _serviceFabric;
    private GunViewService _leftGunViewService;
    private GunViewService _rightGunViewService;
    private PcGunDirectionPanel _pcGunDirectionPanel;

    public void Activate()
    {
        _pcGunDirectionPanel = _viewFabric.Init<PcGunDirectionPanel>();
        _leftGunViewService = _serviceFabric.InitMultiple<GunViewService>();
        _leftGunViewService.Activate(_pcGunDirectionPanel.GetLeftCurrentDirection);

        _rightGunViewService = _serviceFabric.InitMultiple<GunViewService>();
        _rightGunViewService.Activate(_pcGunDirectionPanel.GetRightCurrentDirection);
    }

    public void Deactivate() 
    {

    }
}

