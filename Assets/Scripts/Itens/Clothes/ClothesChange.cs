using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Clothes;

namespace Clothes
{
    public class ClothesChange : MonoBehaviour
    {
        public SkinnedMeshRenderer skinnedMeshRenderer;
        public Texture2D texture;
        public string idName = "_EmissionMap";
        private Texture2D _defaultTexture;
        public void Awake()
        {
            _defaultTexture=(Texture2D)skinnedMeshRenderer.sharedMaterials[0].GetTexture(idName);
        }
        [NaughtyAttributes.Button]
        private void ChangeTexture()
        {
            skinnedMeshRenderer.materials[0].SetTexture(idName, texture);
        }

        public void ChangeTexture(ClothesSetup setup, float duration)
        {
            skinnedMeshRenderer.materials[0].SetTexture(idName, setup.texture);


        }
        public void ResetTexture()
        {
            skinnedMeshRenderer.materials[0].SetTexture(idName, _defaultTexture);

        }
    }
}
