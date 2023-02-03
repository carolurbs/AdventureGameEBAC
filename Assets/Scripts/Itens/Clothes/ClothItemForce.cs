using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Clothes
{

public class ClothItemForce : ClothItemBase
{
        public float damageMultiplier=.5f;
        public override void Collect()
        {
            base.Collect();
            Player.Instance.healthBase.ChangeForce(damageMultiplier, duration);
        }
    }
}
