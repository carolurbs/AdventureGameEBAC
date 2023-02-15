using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Clothes;
namespace Clothes
{
public class ClothItemBase : MonoBehaviour
{
        public ClothParameterBase clothParameters;
        public string compareTag = "Player";
        public AudioSource sfx;
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
           var setup=  ClothesManager.Instance.GetSetupByType(clothParameters.clothType);
            Player.Instance.clothsChanger.ChangeTexture(setup,clothParameters.duration);
            if(sfx != null) sfx.Play();
        }
        private void HideObject()
        {
            gameObject.SetActive(false);
        }
    }

}
