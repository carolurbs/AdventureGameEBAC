using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroAbilityShoot : PlayerAbilityBase
{

    public GunBase gunOne;
    public GunBase gunTwo;
    public Transform gunPosition;

    private GunBase _currentGun;
    protected override void Init()
    {
        base.Init();
        CreateGunOne();
        inputs.Gameplay.Shoot.performed+=ctx=>StartShoot();
        inputs.Gameplay.Shoot.canceled += ctx => StartShoot();
        inputs.Gameplay.Gun1.performed += ctx => CreateGunOne();
        inputs.Gameplay.Gun1.canceled += ctx => CreateGunOne();
        inputs.Gameplay.Gun2.performed += ctx => CreateGunTwo();
        inputs.Gameplay.Gun2.canceled += ctx => CreateGunTwo();


    }
    private void CreateGunOne()
    {
        Destroy(gunTwo);
        if(_currentGun!= null)_currentGun=Instantiate(gunOne, gunPosition);
        _currentGun.transform.localPosition = _currentGun.transform.localEulerAngles = Vector3.zero;
    }

    private void CreateGunTwo()
    {
        Destroy(gunOne);
        if (_currentGun != null) _currentGun = Instantiate(gunTwo, gunPosition);
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
