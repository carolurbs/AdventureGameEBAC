using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Clothes
{
public class ClothItemSpeed : ClothItemBase
{
        public override void Collect()
        {
            base.Collect();
            Player.Instance.ChangeSpeed(((ClothParameterSpeed)clothParameters).targetSpeed, clothParameters.duration) ;
        }
        public static void ApplySpeedPowerUP(Player p, float targetSpeed, float duration)
        {

            p.ChangeSpeed(targetSpeed, duration);
        }
    }

}
