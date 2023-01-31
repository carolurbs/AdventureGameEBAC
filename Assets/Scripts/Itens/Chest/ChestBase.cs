using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class ChestBase : MonoBehaviour
{
    public Animator animator;
    public string triggerOpen = "Open";
    public string triggerClose= "Close";
    public bool isOpen;
    public GameObject notification;
    public float tweenDuration=.2f;
    public Ease ease=Ease.OutBack;
    private float startScale;

    private void Start()
    {
        startScale = notification.transform.localScale.x;
       HideNotification();

    }

    [NaughtyAttributes.Button]
  private  void OpenChest()
    {
        if (!isOpen)
        { 
            animator.SetTrigger(triggerOpen);
               isOpen = true;
        }
    }
    [NaughtyAttributes.Button]
    private void CloseChest()
    {
        if (isOpen)
        {
            animator.SetTrigger(triggerClose);
            isOpen = false;

        }


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
