using System;
using UnityEngine;

public class DamageComponent: MonoBehaviour
{
    public Action DamageAction;
    private float _damage;
    private Type _filterType;

    public void Activate(float damage, Type filterType)
    {
        _damage = damage;
        _filterType = filterType;
    }


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out IHpComponent hpComponent) && collision.GetComponent(_filterType))
        {
            hpComponent.TakeDamage(_damage);
            DamageAction.Invoke();
        }
    }

    public void Deactivate()
    {

    }
}

