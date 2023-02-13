using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using Clothes;
public class HealthBase : MonoBehaviour, IDamageable

{
    public float startLife = 50f;
    public bool destroyOnKill = false;
    public float _currentLife;
    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;
    public UIGunUpdater uiGunUpdater;
    public float damageMultiplier = 1;
    public ClothType? activeClothType = null;

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

        _currentLife -= f*damageMultiplier;
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
    public void ChangeForce(float damageMultiplier, float duration)
    {
        StartCoroutine(ChangeForceCoroutine(damageMultiplier, duration));

    }
    IEnumerator ChangeForceCoroutine(float damageMultiplier , float duration)
    {
        activeClothType = ClothType.FORCE;
        this.damageMultiplier = damageMultiplier;
        yield return new WaitForSeconds(duration);
        this.damageMultiplier = 1;
        activeClothType = null;

    }
}
