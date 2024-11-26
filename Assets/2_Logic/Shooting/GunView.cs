using UniRx;
using UnityEngine;
using Zenject;

public class GunView: MonoBehaviour
{
    public TargetFinderComponent TargetFinderComponent;
    public Transform AimPointTrn;
    private Transform CurrentAimPointTargetTrn;
    public void Activate()
    {

    }

    public void ChangeDirection(Vector3 dir)
    {
        transform.right = dir;
    }

    public void Update()
    {
        UpdateAimPointPos();
    }
    private void UpdateAimPointPos()
    {
        if (CurrentAimPointTargetTrn != null)
        {
            AimPointTrn.position = CurrentAimPointTargetTrn.position;
        }
        else
        {
            AimPointTrn.position = transform.right * 5;
        }
    }
    public void ChangeAimPoint(Transform AimPointTargetTrn)
    {
        CurrentAimPointTargetTrn = AimPointTargetTrn;
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
    private GunDirectionPanel _gunDirectionPanel;
    public void Activate()
    {
        _gunView = _viewFabric.Init<GunView>();
        _gunView.Activate();

        _gunView.TargetFinderComponent.ActivateComponent(typeof(EnemyView));
        _gunView.TargetFinderComponent.CurrentTarget.Subscribe(value =>
        {
            _gunView.ChangeAimPoint(value);
        });

        _gunDirectionPanel = _viewFabric.Init<GunDirectionPanel>();
        _gunDirectionPanel.CurrentDirection.Subscribe(value => {
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
