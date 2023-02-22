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
        public void Start()
        {
            LoadItensFromLastSave();
        }
        private  void LoadItensFromLastSave()
        {
             if(SaveManager.Instance.Setup.activeCloth !=null)
            {

                float duration = ApplyPowerUpOnPlayer(SaveManager.Instance.Setup.activeCloth.value) ;
                var setup = GetSetupByType(SaveManager.Instance.Setup.activeCloth.value);
                Player.Instance.clothsChanger.ChangeTexture(setup,duration);
            }
        }
        public ClothesSetup GetSetupByType(ClothType cloth)
        {
            return clothesSetups.Find(i => i.clothType == cloth);   
        }
        public  void ApplyPowerUpOnPlayer(ClothType clothType)
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
                return-1;
            }
           switch (clothType)
            {
                case ClothType.FORCE:
                    ClothParametersForce f =(ClothParametersForce)parameters;
                    ClothItemForce.ApplyForcePowerUP(Player.Instance, f.damageMultiplier,f.duration);
                    return f.duration;
                    case ClothType.SPEED:
                    ClothParameterSpeed s = (ClothParameterSpeed)parameters;
                    ClothItemSpeed.ApplySpeedPowerUP(Player.Instance, s.targetSpeed, s.duration);
                    return s.duration;
                    default:
                    Debug.LogError("Don't know the given coth type" + clothType);
                    
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
