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
    private GunBase gunOneInstance;
    private GunBase gunTwoInstance;
   
    private void SwitchGun(GunEquippedNumber gunNumber)
    {
        switch(gunNumber)
        {
            case GunEquippedNumber.One:
                gunOneInstance.gameObject.SetActive(true);
                gunTwoInstance.gameObject.SetActive(false);
                _currentGun = gunOneInstance;
                break;
                case GunEquippedNumber.Two:
                gunOneInstance.gameObject.SetActive(false);
                gunTwoInstance.gameObject.SetActive(true);
                _currentGun = gunTwoInstance;
                break;

                default:
                Debug.LogError("Don't know the given gunNumber:" +gunNumber.ToString());
                break;
        }
    }
    protected override void Init()
    {
        base.Init();
        CreateGunOne();
        CreateGunTwo();
        inputs.Gameplay.Shoot.performed+=ctx=>StartShoot();
        inputs.Gameplay.Shoot.canceled += ctx => CancelShoot();
        inputs.Gameplay.Gun1.performed += ctx => SwitchGun(GunEquippedNumber.One);
        inputs.Gameplay.Gun2.performed += ctx => SwitchGun(GunEquippedNumber.Two);


    }
    private void CreateGunOne()
    {
  
            gunOneInstance = Instantiate(gunOne, gunPosition);
            gunOneInstance.transform.localPosition = gunOneInstance.transform.localEulerAngles = Vector3.zero;
        _currentGun = gunOneInstance;
         


    }

    private void CreateGunTwo()
    
    {
     

        gunTwoInstance= Instantiate(gunTwo, gunPosition);
        gunTwoInstance.transform.localPosition = gunTwoInstance.transform.localEulerAngles = Vector3.zero;
        _currentGun = gunTwoInstance;

    }

 
    private void StartShoot()
    {
        _currentGun.StartShoot();
        Debug.Log("Start Shoot");
    }

    private void CancelShoot()
    {
      _currentGun.StopShoot();
        Debug.Log("Cancel Shoot");

    }

    public enum GunEquippedNumber
    {
        One,
        Two
    }
}
