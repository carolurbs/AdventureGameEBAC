using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Itens
{

public class ItemCollectableBase: MonoBehaviour
{
        public SFXType sfxType;
        public ItemType itemType;
        public Collider collider;
    public string compareTag = "Player";
    public float timeToHide = 3;
    public GameObject graphicItem;
 
    private void Awake()
    {
          
            collider.enabled = true; 
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.transform.CompareTag(compareTag))
        {
            Collect();
        }
    }
    protected virtual void Collect()
    {
        PlaySFX();
        Debug.Log("Collect");
      Invoke(nameof(OnCollect), timeToHide);
    }
    protected virtual void OnCollect()
    {
    if(graphicItem!=null)  
    graphicItem.SetActive(false);

           ItemManager.Instance.AddByType(itemType);   
            collider.enabled = false;
    }
  private void PlaySFX()
  {
    SFX_Pool.Instance.Play(sfxType);
  }

}
}
