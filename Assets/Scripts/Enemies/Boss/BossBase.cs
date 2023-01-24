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

    }

public class BossBase : MonoBehaviour

{
        [Header("Animation")]
        public float startAnimationDuration= .5f;
        public Ease startAnimationEase=Ease.OutBack; 
       
        private StateMachine<BossAction> stateMachine;
        public float speed= 5f;
        public List<Transform> waypoints;
        private void Awake()
        {
            Init();

        }
        private void Init()
        {
          stateMachine= new StateMachine<BossAction>();
            stateMachine.Init();
            stateMachine.RegisteredStates(BossAction.INIT, new BossStateInit());
            stateMachine.RegisteredStates(BossAction.WALK, new BossStateWalk());

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
        public void GoToRandomPoint()
        {
        StartCoroutine(GoToPointCoroutine(waypoints[Random.Range(0,waypoints.Count)]));
        }
         IEnumerator GoToPointCoroutine(Transform t)
        {
            while(Vector3.Distance(transform.position, t.position)>1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, t.position, Time.deltaTime * speed);
                yield return new WaitForEndOfFrame();
            }
        }
        #endregion

    }
}
