using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Itens
{

public class ItemCollectableBase: MonoBehaviour
{
        public ItemType itemType;
        public Collider collider;
    public string compareTag = "Player";
    public float timeToHide = 3;
    public GameObject graphicItem;
    //public ParticleSystem _particleSystem;
    /*[Header("Sounds")]
    public AudioSource audioSource;*/
    private void Awake()
    {
            /*    if (_particleSystem != null)   _particleSystem.transform.SetParent(null);
                if (audioSource != null) audioSource.transform.SetParent(null);*/
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
        Debug.Log("Collect");
      Invoke(nameof(OnCollect), timeToHide);
    }
    protected virtual void OnCollect()
    {
    if(graphicItem!=null)  
    graphicItem.SetActive(false);
    /* if (_particleSystem != null) _particleSystem.Play();
            if (audioSource != null) audioSource.Play();*/
           ItemManager.Instance.AddByType(itemType);   
            collider.enabled = false;
    }

}
}
