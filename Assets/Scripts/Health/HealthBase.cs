using System;
using System.Collections.Generic;
using UnityEngine;
public class HealthBase : MonoBehaviour, IDamageable

{
    public float startLife = 50f;
    public bool destroyOnKill = false;
    public float _currentLife;
    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;
    public UIGunUpdater uiGunUpdater;
    private void Awake()
    {

        Init();
    }

    protected virtual void Init()
    {
        ResetLife();

    }

    public void ResetLife()
    {

        _currentLife = startLife;
        UpdateUI();
    }
    public virtual void Kill()

    {
        if (destroyOnKill)
            Destroy(gameObject, 3f);

        OnKill?.Invoke(this);
      

    }
   
    public void Damage(GameObject gameObject)
    {
        Damage(5);
    }
    public void Damage(float f)
    {

        _currentLife -= f;
        if (_currentLife <= 0)
        {
            Kill();
        }
        UpdateUI();
        OnDamage?.Invoke(this);

    }
    public void Damage(float damage, Vector3 dir)
    {
        Damage(damage);
    }
    private void UpdateUI()
    {
        if(uiGunUpdater!=null)
        {
            uiGunUpdater.UpdateValue((float) _currentLife/startLife);
        }
    }

    internal void Damage(object damage)
    {
        throw new NotImplementedException();
    }
}
