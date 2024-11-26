using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ShootingService
{
    [Inject] private IServiceFabric _serviceFabric;
    private GunViewService _leftGunViewService;
    private GunViewService _rightGunViewService;

    public void Activate()
    {
        _leftGunViewService = _serviceFabric.InitMultiple<GunViewService>();
        _leftGunViewService.Activate();    
    }

    public void Deactivate() 
    {

    }
}

