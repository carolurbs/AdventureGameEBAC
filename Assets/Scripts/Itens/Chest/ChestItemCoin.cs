using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Itens;
public class ChestItemCoin : ChestItemBase
{
    public int coinNumber = 5;
    public GameObject coinObject;
    public List<GameObject> _itens = new List<GameObject>();
    public Vector2 randomRange= new Vector2(-1f,1f);
    public float tweenEndTime=.5f; 
    public override void ShowItem()
    {
        base.ShowItem();
        CreateItens();
    }
    [NaughtyAttributes.Button]
    private void CreateItens()
    {
        for(int i = 0; i < coinNumber; i++)
        {
            var item = Instantiate(coinObject);
            item.transform.position = transform.position + Vector3.forward * Random.Range(randomRange.x, randomRange.y) + Vector3.right * Random.Range(randomRange.x, randomRange.y) ;
            item.transform.DOScale(0, .2f).SetEase(Ease.OutBack).From();
            _itens.Add(item);
        }
    }
    [NaughtyAttributes.Button]

    public override void Collect()
    {
        base.Collect();
        foreach(var i in _itens)
        {
            i.transform.DOMoveY(2f, tweenEndTime).SetRelative();
            i.transform.DOScale(0, tweenEndTime / 2).SetDelay(tweenEndTime / 2);
            ItemManager.Instance.AddByType(ItemType.COIN);
        }
    }
}
