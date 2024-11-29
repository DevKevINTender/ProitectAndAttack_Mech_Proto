using System;
using UnityEngine;
using Zenject;

public class BulletView: MonoBehaviour
{
    public DamageComponent DamageComponent;
    public MoveToDirectionComponent MoveComponent;
    public WallDetectComponent WallDetectComponent;
    public void Init()
    {

    }
    public void Activate(Vector3 spawnPos, Transform targetTrn)
    {
        transform.position = spawnPos;
        transform.right = transform.position - targetTrn.position;
        gameObject.SetActive(true);
    }
    public void Deactivate(Transform poolTrn)
    {
        gameObject.SetActive(false);
        transform.SetParent(poolTrn);
        transform.GetComponent<TrailRenderer>().Clear();
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

        _bulletView.Activate(spawnPos, targetTrn);
        _bulletView.DamageComponent.Activate(1, filterType);
        _bulletView.DamageComponent.DamageAction = Deactivate;
        _bulletView.MoveComponent.Activate(targetTrn.position, 10f);
        _bulletView.WallDetectComponent.WallDetectedAction = Deactivate;
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