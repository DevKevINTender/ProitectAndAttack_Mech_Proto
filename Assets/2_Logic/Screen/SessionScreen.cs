using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class SessionScreen : MonoBehaviour
{    
}

public class SessionScreenService
{
    [Inject] private IViewFabric _viewFabric;
    private SessionScreen _sessionScreen;
    public void Activate()
    {
        _sessionScreen = _viewFabric.Init<SessionScreen>();
    }
    public void Deactivate()
    {

    }
}
