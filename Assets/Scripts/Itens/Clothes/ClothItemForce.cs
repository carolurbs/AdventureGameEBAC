using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clothes
{

public class ClothItemForce : ClothItemBase
{
        public override void Collect()
        {
            base.Collect();
            Player.Instance.healthBase.ChangeForce(((ClothParametersForce)clothParameters).damageMultiplier, clothParameters.duration);
        }

        public static void ApplyForcePowerUP(Player p, float damageMultiplier, float duration)
        {

            p.healthBase.ChangeForce(damageMultiplier, duration);   
        }
    }
}
