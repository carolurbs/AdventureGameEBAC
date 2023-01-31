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
    public class BossStateWalk : BossStates
    {
        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
            boss.GoToRandomPoint(OnArrive);
        }
        private void OnArrive()
        {
            boss.SwitchState(BossAction.ATTACK);
        }
        public override void OnStateExit()
        {
            base.OnStateExit();
            boss.StopAllCoroutines();
        }
    }
    public class BossStateAttack : BossStates
    {
        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
            boss.StartAttack(EndAttacks);
        }
        private void EndAttacks()

        {
            boss.SwitchState(BossAction.WALK);

        }
    }
    public class BossStateDeath : BossStates
    {

        public override void OnStateEnter(params object[] objs)
        {
            base.OnStateEnter(objs);
            boss.transform.localScale = Vector3.one*.2f;
            boss.OnDeath();
        }
    }

    }

