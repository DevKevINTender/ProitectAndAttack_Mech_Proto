using System;
using UnityEngine;
using Zenject;

public interface IPoolingViewService
{
    public void ActivateFromPool(Action<IPoolingViewService> action);
    public void DeactivateToPool();
}
public class PoolingViewService: IPoolingViewService
{
    protected Transform poolTrn;
    [Inject] private IViewPoolService _viewPoolService;
    private Action<IPoolingViewService> _deactivateAction;

    public void ActivateFromPool(Action<IPoolingViewService> action)
    {
        _deactivateAction = action;
        poolTrn = _viewPoolService.GetPoolTransfrom();
    }

    public void DeactivateToPool()
    {
        _deactivateAction.Invoke(this);
    }
}
