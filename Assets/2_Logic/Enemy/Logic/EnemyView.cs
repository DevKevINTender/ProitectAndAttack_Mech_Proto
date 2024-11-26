using UnityEngine;
using Zenject;

public class EnemyView : MonoBehaviour
{
    public MoveToPositionComponent MoveComponent;
    public HpComponent HpComponent;
    public DamageComponent DamageComponent;
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
}

public class EnemyViewService: PoolingViewService
{
    [Inject] private IViewFabric _viewFabric;
    private EnemyView _enemyView;

    public void Activate(Vector3 spawnPos, EnemyType enemyType)
    {
        if (_enemyView == null)
            _enemyView = _viewFabric.Init<EnemyView>(spawnPos);

        _enemyView.Activate(spawnPos);
        _enemyView.MoveComponent.Activate(Vector2.zero, 2);
        _enemyView.HpComponent.Activate(2);
        _enemyView.HpComponent.DieAction = Deactivate;
        _enemyView.DamageComponent.Activate(1, typeof(UnitView));
        _enemyView.DamageComponent.DamageAction = Deactivate;
    }

    public void Deactivate()
    {
        _enemyView.MoveComponent.Deactivate();
        _enemyView.HpComponent.Deactivate();
        _enemyView.Deactivate(poolTrn);
        DeactivateToPool();
    }
}

