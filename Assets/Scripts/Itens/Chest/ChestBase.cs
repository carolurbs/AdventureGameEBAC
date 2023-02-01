using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class ChestBase : MonoBehaviour
{
    public KeyCode keyCode = KeyCode.Z;
    public Animator animator;
    public string triggerOpen = "Open";
    public string triggerClose= "Close";
    public bool isOpen;
    public GameObject notification;
    public float tweenDuration=.2f;
    public Ease ease=Ease.OutBack;
    public ChestItemBase chestItem;
    private float startScale;

    private void Start()
    {
        startScale = notification.transform.localScale.x;
       HideNotification();

    }
    private void Update()
    {
        if(Input.GetKeyDown(keyCode) && notification.activeSelf)
        {
            if (!isOpen)
            {
               OpenChest();
                isOpen = true;
                Invoke(nameof(ShowItem),.5f); 
            }
            else
            {
                CloseChest();
                isOpen = false;

            }
            HideNotification();
        }
    }
    private void  ShowItem()
    {
        chestItem.ShowItem();
        Invoke(nameof(CollectItem), 1f);

    }
    private void CollectItem()
    {
        chestItem.Collect();
    }
    [NaughtyAttributes.Button]
  private  void OpenChest()
    {
        animator.SetTrigger(triggerOpen);
    }
    [NaughtyAttributes.Button]
    private void CloseChest()
    {

            animator.SetTrigger(triggerClose);

    }

    public void OnTriggerEnter(Collider other)
    {
        Player p =other.transform.GetComponent<Player>();   
        if(p != null)
        {
            ShowNotification();
        }
        
    }
    public void OnTriggerExit(Collider other)
    {
        Player p = other.transform.GetComponent<Player>();
        if (p != null)
        {
            HideNotification();
        }

    }
    private void ShowNotification()
    {
       notification.SetActive(true);
        notification.transform.localScale = Vector3.zero;
        notification.transform.DOScale(startScale, tweenDuration);
    }
    private void HideNotification()
    {
        notification.SetActive(false);
    }
}
