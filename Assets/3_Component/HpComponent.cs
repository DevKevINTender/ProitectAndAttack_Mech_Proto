using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IHpComponent
{
    public void Activate(float hp);
    public void TakeDamage(float damage);
    public void Deactivate();
    public float GetFillValue();
}

public class HpComponent: MonoBehaviour, IHpComponent
{
    public Action DieAction;
    [SerializeField] private float _hp;
    private float _maxHp;

    public void Init() { }
    public void Activate(float hp)
    {
        _maxHp = hp;
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

    public float GetFillValue()
    {
        return _hp/_maxHp;
    }
}
