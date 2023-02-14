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
        public List<ClothParameterBase> clothParameters;

        private void LoadItensFromLastSave()
        {
           //ApplyPowerUpOnPlayer(clothParameters);
        }
        public ClothesSetup GetSetupByType(ClothType cloth)
        {
            return clothesSetups.Find(i => i.clothType == cloth);   
        }
        public void ApplyPowerUpOnPlayer(ClothType clothType)
        {
            ClothParameterBase parameters = null; 
            for(int i = 0; i < clothParameters.Count; i++)
            {
            if (clothParameters[i].clothType==clothType)
                {
                    parameters = clothParameters[i];
                    break;
                }

            }
           if(parameters==null)
            {
                Debug.LogError("Couldn't find the given cloth type on the parameters list:"+ clothType);
                return;
            }
           switch (clothType)
            {
                case ClothType.FORCE:
                    ClothParametersForce f =(ClothParametersForce)parameters;
                    ClothItemForce.ApplyForcePowerUP(Player.Instance, f.damageMultiplier,f.duration);
                    break;
                    case ClothType.SPEED:
                    ClothParameterSpeed s = (ClothParameterSpeed)parameters;
                    ClothItemSpeed.ApplySpeedPowerUP(Player.Instance, s.targetSpeed, s.duration);
                    break;
            }
        }
}
    [System.Serializable]
 public class ClothesSetup
    {
        public ClothType clothType;
        public Texture2D texture;  

    }
}
