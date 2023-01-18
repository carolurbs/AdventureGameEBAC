using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroAbilityShoot : PlayerAbilityBase
{
    public GunBase gunBase;
    public Transform gunPosition;

    private GunBase _currentGun;
    protected override void Init()
    {
        base.Init();
        CreateGun();
        inputs.Gameplay.Shoot.performed+=ctx=>StartShoot();
        inputs.Gameplay.Shoot.canceled += ctx => StartShoot();

    }
    private void CreateGun()
    {
        _currentGun=Instantiate(gunBase, gunPosition);
        _currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
    }

    private void StartShoot()
    {
        _currentGun.StartShoot();
        Debug.Log("Start Shoot");
    }

    private void CancelShoot()
    {
      _currentGun.StopShoot();
        Debug.Log("Cancwl Shoot");

    }
}
