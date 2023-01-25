using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.StateMachine;
using DG.Tweening;
namespace Boss
{
    public enum BossAction
    {
        INIT, 
        IDLE,
        WALK, 
        ATTACK,
        DEATH

    }

public class BossBase : MonoBehaviour

{
        [Header("Animation")]
        public float startAnimationDuration= .5f;
        public Ease startAnimationEase=Ease.OutBack;

        [Header("Attack")]
        public int attackAmount = 5;
        public float timeBetweenAttacks = .5f;
        private StateMachine<BossAction> stateMachine;
        public float speed= 5f;
        public List<Transform> waypoints;
        public HealthBase healthBase;

        private void Awake()
        {
            Init();
            healthBase.OnKill += OnBossKill;
        }
        private void Init()
        {
          stateMachine= new StateMachine<BossAction>();
            stateMachine.Init();
            stateMachine.RegisteredStates(BossAction.INIT, new BossStateInit());
            stateMachine.RegisteredStates(BossAction.WALK, new BossStateWalk());
            stateMachine.RegisteredStates(BossAction.ATTACK, new BossStateAttack());
            stateMachine.RegisteredStates(BossAction.DEATH, new BossStateDeath());

        }
        #region DEBUG
        [NaughtyAttributes.Button]
        private void SwitchInit()
        {
            SwitchState(BossAction.INIT);
        }

        [NaughtyAttributes.Button]
        public void SwitchWalk()
        {
            SwitchState(BossAction.WALK);

        }
        [NaughtyAttributes.Button]
        public void SwitchAttack()
        {
            SwitchState(BossAction.ATTACK);

        }
        #endregion
        #region STATE MACHINE 
        public void SwitchState(BossAction state)
        {
            stateMachine.SwitchState(state, this);
        }
        #endregion
        #region Animation 
        public void StartInitAnimation()
        {
            transform.DOScale(0,startAnimationDuration).SetEase(startAnimationEase).From();
            
        }
        #endregion
        #region Walk
        public void GoToRandomPoint(Action onArrive=null)
        {
        StartCoroutine(GoToPointCoroutine(waypoints[UnityEngine.Random.Range(0,waypoints.Count)], onArrive));
        }
         IEnumerator GoToPointCoroutine(Transform t, Action onArrive=null)
        {
            while(Vector3.Distance(transform.position, t.position)>1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, t.position, Time.deltaTime * speed);
                yield return new WaitForEndOfFrame();
            }
          onArrive?.Invoke();
        }
        #endregion
        #region ATTACK 
        public void StartAttack(Action endCallback)
        {
            StartCoroutine(AttackCoroutine());
        }
        IEnumerator AttackCoroutine(Action endCallback= null)
        {
            int attacks= 0;
            while (attacks<attackAmount)
            {
                attacks++;
                transform.DOScale(1.1f, .1f).SetLoops(2,LoopType.Yoyo);
                yield return new WaitForSeconds(timeBetweenAttacks);
            }
            endCallback?.Invoke();
        }

        #endregion
        #region DEATH
        private void OnBossKill(HealthBase h)
        {
            SwitchState(BossAction.DEATH);
        }
        #endregion



    }
}
