using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeroAbilityShoot : PlayerAbilityBase
{
    public GunBase gunBase;
    protected override void Init()
    {
        base.Init();
        inputs.Gameplay.Shoot.performed+=ctx=>StartShoot();
        inputs.Gameplay.Shoot.canceled += ctx => StartShoot();

    }

    private void StartShoot()
    {
        gunBase.StartShoot();
        Debug.Log("Start Shoot");
    }

    private void CancelShoot()
    {
      gunBase.StopShoot();
        Debug.Log("Cancwl Shoot");

    }
}
