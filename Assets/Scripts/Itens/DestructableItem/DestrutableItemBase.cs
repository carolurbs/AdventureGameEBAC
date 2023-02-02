using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DestrutableItemBase : MonoBehaviour
{
    public HealthBase healthBase ;
    public float shakeDuration = .1f;
    public int shakeForce= 5;
    public List<FlashColor> flashColors;
    public int dropItemAmount = 10;
    public GameObject coinPrefab;
    public Transform dropPosition;
    public bool _alive = true;


    public void OnValidate()
    {
        if (healthBase ==null) healthBase =GetComponent<HealthBase>();
        
        

    }
    private void Awake()
    {
        OnValidate();
        healthBase.OnDamage += OnDamage;
        healthBase.OnKill += OnKill;

    }
    [NaughtyAttributes.Button]
    private void OnDamage (HealthBase h)
    {
      gameObject.transform.DOShakeScale(shakeDuration, Vector3.up/2, shakeForce);
        flashColors.ForEach(i => i.Flash());
        DropCoins();
        if(healthBase._currentLife<=0)
        {
            OnKill(healthBase);
        }

    }
    [NaughtyAttributes.Button]
    private void  DropCoins()
    {
        var i = Instantiate(coinPrefab);
        i.transform.position = transform.position;
        i.transform.DOScale(0, 1f).SetEase(Ease.OutBack).From(); 
    }
    [NaughtyAttributes.Button]
    private void OnKill(HealthBase h)
    {
        if (_alive)
        {
            _alive = false;
        }
    }
}
