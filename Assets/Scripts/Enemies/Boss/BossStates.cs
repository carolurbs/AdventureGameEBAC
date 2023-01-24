using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;
namespace Boss
{
   
public class BossStates: StateBase
{
        protected BossBase boss;
        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
            boss =(BossBase)objs[0]; 
        }
    }
public class BossStateInit: BossStates
    {
        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
            boss.StartInitAnimation();
        }
    }
    public class BossStateWalk: BossStates
    {
        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
            boss.GoToRandomPoint();
        }
    }
}
