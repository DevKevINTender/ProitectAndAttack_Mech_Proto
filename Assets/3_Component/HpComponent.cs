using System;
using UnityEngine;

public interface IHpComponent
{
    public void Activate(float hp);
    public void TakeDamage(float damage);
    public void Deactivate();
}

public class HpComponent: MonoBehaviour, IHpComponent
{
    public Action DieAction;
    [SerializeField] private float _hp;

    public void Init() { }
    public void Activate(float hp)
    {
        _hp = hp;
    }

    public void TakeDamage(float damage)
    {
        _hp -= damage;
        if(_hp <= 0)
        {
            DieAction?.Invoke();
        }
    }

    public void Deactivate()
    {
        _hp = 0;
    }
    public void Final() { }
}
