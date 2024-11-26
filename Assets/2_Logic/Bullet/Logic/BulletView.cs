using System;
using System.Collections;
using UniRx;
using UnityEngine;
using Zenject;

public class BulletView: MonoBehaviour
{
    public DamageComponent DamageComponent;
    public MoveToDirectionComponent MoveComponent;
    public void Init()
    {

    }
    public void Activate(Vector3 spawnPos)
    {
        transform.position = spawnPos;
        gameObject.SetActive(true);
    }
    public void Deactivate(Transform poolTrn)
    {
        gameObject.SetActive(false);
        transform.SetParent(poolTrn);
        transform.localPosition = Vector3.zero;
    }
    public void Final()
    {

    }
}

public class BulletViewService : PoolingViewService
{
    [Inject] private IViewFabric _viewFabric;
    private BulletView _bulletView;

    public void Init()
    {
    }

    public void Activate(Vector3 spawnPos, Transform targetTrn, Type filterType)
    {
        if(_bulletView == null)
            _bulletView = _viewFabric.Init<BulletView>();

      

        _bulletView.Activate(spawnPos);
        _bulletView.DamageComponent.Activate(1, filterType);
        _bulletView.DamageComponent.DamageAction = Deactivate;
        _bulletView.MoveComponent.Activate(targetTrn.position, 10f);
    }

    public void Deactivate()
    {
        _bulletView.DamageComponent.Deactivate();
        _bulletView.MoveComponent.Deactivate();
        _bulletView.Deactivate(poolTrn);
        DeactivateToPool();
    }

    public void Final()
    {

    }
}
