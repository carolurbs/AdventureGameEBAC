using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBase : MonoBehaviour

{
    public ProjectileBase prefabProjectille;
    public Transform positionToShoot;
    public float timeBetweenShoot = .3f;
    private Coroutine _currentCoroutine;

    protected virtual IEnumerator ShootCoroutine()
    {
        while(true)
        {
            Shoot();
            yield return new WaitForSeconds(timeBetweenShoot);
        }
    }
    public void Shoot()
    {
        var projectille = Instantiate(prefabProjectille);
        projectille.transform.position = positionToShoot.position;
        projectille.transform.rotation = positionToShoot.rotation;
    }
    public void StartShoot()
    {
        StopShoot();    
        _currentCoroutine = StartCoroutine(ShootCoroutine());

    }
    public void StopShoot()
    {
        if (_currentCoroutine != null) StopCoroutine(_currentCoroutine);
    }
}
