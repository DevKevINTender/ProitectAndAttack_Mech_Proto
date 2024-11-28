using UniRx;
using UnityEngine;
using Zenject;

public class GunView: MonoBehaviour
{
    public TargetFinderComponent TargetFinderComponent;

    public void Activate()
    {

    }

    public void ChangeDirection(Vector3 dir)
    {
        transform.right = dir;
    }

    
   

    public void Deactivate()
    {

    }
}

public class GunViewService
{
    [Inject] private IViewFabric _viewFabric;
    [Inject] private IServiceFabric _serviceFabric;
    private BulletShootService _bulletShootService;
    private GunView _gunView;
    private AimPointView _aimPointView;
    private ReactiveProperty<Vector3> _gunDirection;
    public void Activate(ReactiveProperty<Vector3> gunDiretion, GameObject AimPointPb)
    {
        _gunDirection = gunDiretion;

        _gunView = _viewFabric.Init<GunView>();
        _gunView.Activate();

        _gunView.TargetFinderComponent.ActivateComponent(typeof(EnemyView));

        _aimPointView = _viewFabric.Init<AimPointView>(AimPointPb, _gunView.transform);
        _gunView.TargetFinderComponent.CurrentTarget.Subscribe(value =>
        {
            _aimPointView.ChangeAimPoint(value);
        });

        _gunDirection.Subscribe(value => {
            _gunView.ChangeDirection(value);
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
