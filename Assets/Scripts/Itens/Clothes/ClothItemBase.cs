using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Clothes;
namespace Clothes
{
public class ClothItemBase : MonoBehaviour
{
public ClothType clothType;
        public float duration = 2f;
 public string compareTag = "Player";
        private void OnTriggerEnter(Collider collision)
        {
            if (collision.transform.CompareTag(compareTag))
            {
                Collect();
            }
        }
        public virtual void Collect()
        {
            HideObject();
            Debug.Log("Collect");
           var setup=  ClothesManager.Instance.GetSetupByType(clothType);
            Player.Instance.clothsChanger.ChangeTexture(setup, duration);
        }
        private void HideObject()
        {
            gameObject.SetActive(false);
        }
    }

}
