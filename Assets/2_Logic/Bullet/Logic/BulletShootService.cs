using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class BulletShootService
{
    public Action OnStartShootAction;
    public Action OnStopShootAction;
    [Inject] private IViewServicePoolService _poolsViewService;
    private IViewServicePool _bulletPoolViewService;
    private TargetFinderComponent _targetFinderComponent;
    private ReactiveProperty<float> _intervalProperty = new ReactiveProperty<float>(1f);
    private CompositeDisposable _disposables = new();
    private Transform _spawPos;
    private Type _bulletFilterType;
    private List<BulletViewService> _bulletViewServices = new();

    public void Activate(
        TargetFinderComponent targetFinderComponent,
        Transform spawPos,
        Type bulletFilterType)
    {

        _targetFinderComponent = targetFinderComponent;
        _spawPos = spawPos;
        _bulletFilterType = bulletFilterType;

        _bulletPoolViewService = _poolsViewService.GetPool<BulletViewService>();
        _intervalProperty
            .Select(interval => Observable.Interval(TimeSpan.FromSeconds(interval)))
            .Switch()
            .Subscribe(_ =>
            {
                
                if (_targetFinderComponent.CurrentTarget.Value != null)
                {
                    Shoot();
                    OnStartShootAction?.Invoke();
                }
                else
                {
                    OnStopShootAction?.Invoke();
                }
            })
            .AddTo(_disposables);

       
    }

    private void Shoot()
    {
        BulletViewService bullet = (BulletViewService)_bulletPoolViewService.GetItem();
        bullet.Activate(
            _spawPos.position,
            _targetFinderComponent.CurrentTarget.Value,
            _bulletFilterType);
        _bulletViewServices.Add(bullet);
    }

    public void Deactivate()
    {
        _disposables.Dispose();
    }
}
