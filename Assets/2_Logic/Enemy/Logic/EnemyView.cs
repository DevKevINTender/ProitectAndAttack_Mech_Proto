using UnityEngine;
using Zenject;

public class EnemyView : MonoBehaviour
{
    public MoveToPositionComponent MoveComponent;
    public HpComponent HpComponent;
    public DamageComponent DamageComponent;
    public void Activate(Vector3 spawnPos)
    {
        gameObject.SetActive(true);
        transform.SetParent(null);
        transform.position = spawnPos;
    }
    public void Deactivate(Transform poolTrn)
    {
        transform.SetParent(poolTrn);
        transform.localPosition = Vector3.zero;
        gameObject.SetActive(false);
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
        _enemyView.MoveComponent.Activate(Vector2.zero, 1);
        _enemyView.HpComponent.Activate(2);
        _enemyView.HpComponent.DieAction = Deactivate;
        _enemyView.DamageComponent.Activate(1, typeof(UnitView));
        _enemyView.DamageComponent.DamageAction = Deactivate;
    }

    public void Deactivate()
    {
        _enemyView.MoveComponent.Deactivate();
        _enemyView.HpComponent.Deactivate();
        _enemyView.DamageComponent.Deactivate();
        _enemyView.Deactivate(poolTrn);
        DeactivateToPool();
    }
}


