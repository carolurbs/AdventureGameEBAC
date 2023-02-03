using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;

namespace Clothes
{
    public enum ClothType
    {
        COLOR,
        SPEED,
        FORCE
    }
public class ClothesManager : Singleton<ClothesManager>
{
        public List<ClothesSetup> clothesSetups;
        public ClothesSetup GetSetupByType(ClothType cloth)
        {
            return clothesSetups.Find(i => i.clothType == cloth);   
        }
}
    [System.Serializable]
 public class ClothesSetup
    {
        public ClothType clothType;
        public Texture2D texture;  

    }
}
