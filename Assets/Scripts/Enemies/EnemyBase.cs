using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace Enemy
{
public class EnemyBase : MonoBehaviour
{
        public float startLife=10f;
        public float _currentLife;
        [Header("Start Animation")]
        public float startAnimationDuration = .2f;
        public Ease startAnimationEase = Ease.OutBack;
        public bool startwithBornAnimation=true;

        private void Awake()
        {
         Init();
        }
        protected void ResetLife()
        {
            _currentLife = startLife;

        }
        protected virtual void Init()
        {
            ResetLife();
            if (startwithBornAnimation)
            BornAnimation();
        }
        protected virtual void Kill()

        {
            OnKill();
        }

        protected virtual void OnKill()
        {
            Destroy(gameObject);

        }

        public void OnDamage(float f)
        {
            _currentLife = -f;
            if(_currentLife<=0)
            {
                Kill();
            }
        }
        #region ANIMATION
        private void BornAnimation()
        {
            transform.DOScale(0, startAnimationDuration).SetEase(startAnimationEase).From();
        }
        #endregion
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.T))
            {
                OnDamage(5f);
                Debug.Log(_currentLife);
            }
        }
    }

}

