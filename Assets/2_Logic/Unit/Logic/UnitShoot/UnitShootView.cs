using UniRx;
using UnityEngine;
using Zenject;

public class UnitShootView: MonoBehaviour
{
    public TargetFinderComponent TargetFinderComponent;

    public void Activate()
    {

    }

    public void ChangeDirection(Vector3 dir)
    {
        transform.right = dir;
    }

    public void FixedUpdate()
    {
        if (TargetFinderComponent.CurrentTarget.Value != null)
        {
            transform.right = TargetFinderComponent.CurrentTarget.Value.position - transform.position;
        }
    }

    public void Deactivate()
    {

    }
}

public class UnitShootViewService
{
    [Inject] private IViewFabric _viewFabric;
    [Inject] private IServiceFabric _serviceFabric;
    private BulletShootService _bulletShootService;
    private UnitShootView _gunView;
    private AimPointView _aimPointView;

    public void Activate(Transform gunPosTrn)
    {
        _gunView = _viewFabric.Init<UnitShootView>(gunPosTrn);
        _gunView.Activate();

        _gunView.TargetFinderComponent.ActivateComponent(typeof(EnemyView));

        _aimPointView = _viewFabric.Init<AimPointView>(_gunView.transform);
        _gunView.TargetFinderComponent.CurrentTarget.Subscribe(value =>
        {
            _aimPointView.ChangeAimPoint(value);
        });

        _bulletShootService = _serviceFabric.InitMultiple<BulletShootService>();
        _bulletShootService.Activate(
            _gunView.TargetFinderComponent,
            _gunView.transform,
            typeof(EnemyView)
            );
    }

    public void Deactivate()
    {

    }
}
