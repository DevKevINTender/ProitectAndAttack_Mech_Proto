using System.Collections;
using System.Collections.Generic;
using Zenject;

public class ShootingService
{
    [Inject] private IViewFabric _viewFabric;
    [Inject] private IServiceFabric _serviceFabric;
    [Inject] private ISOStorageService _isoStorageService;
    private GunViewService _leftGunViewService;
    private GunViewService _rightGunViewService;
    private PcGunDirectionPanel _pcGunDirectionPanel;

    public void Activate()
    {
        ShootingData shootingData = _isoStorageService.GetSOByType<ShootingData>();
        _pcGunDirectionPanel = _viewFabric.Init<PcGunDirectionPanel>();
        _leftGunViewService = _serviceFabric.InitMultiple<GunViewService>();
        _leftGunViewService.Activate(
            _pcGunDirectionPanel.GetLeftCurrentDirection,
            shootingData.LeftAimPointPb);

        _rightGunViewService = _serviceFabric.InitMultiple<GunViewService>();
        _rightGunViewService.Activate(
            _pcGunDirectionPanel.GetRightCurrentDirection,
            shootingData.RightAimPointPb);
    }

    public void Deactivate() 
    {

    }
}

