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
    public void OnValidate()
    {
        if (healthBase ==null) healthBase =GetComponent<HealthBase>();
        
        

    }
    private void Awake()
    {
        OnValidate();
        healthBase.OnDamage += OnDamage;

    }
    private void OnDamage (HealthBase h)
    {
      gameObject.transform.DOShakeScale(shakeDuration, Vector3.up/2, shakeForce);
        flashColors.ForEach(i => i.Flash());
        DropCoins();

    }
    [NaughtyAttributes.Button]
    private void  DropCoins()
    {
        var i = Instantiate(coinPrefab);
        i.transform.position = transform.position;
        i.transform.DOScale(0, 1f).SetEase(Ease.OutBack).From(); 
    }
}
