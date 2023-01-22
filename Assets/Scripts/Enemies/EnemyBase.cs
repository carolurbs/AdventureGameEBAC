using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using AnimationManager;
namespace Enemy
{
public class EnemyBase : MonoBehaviour,IDamageable
{
        public Collider collider;
        public  FlashColor flashColor; 
        public float startLife=10f;
        public float _currentLife;
        public ParticleSystem particleSystem;
        [Header(" Animation")]
        [SerializeField]public AnimationBase animationBase;
        public float startAnimationDuration = .2f;
        public Ease startAnimationEase = Ease.OutBack;
        public bool startwithBornAnimation=true;

        private void Awake()
        {
            if(particleSystem!=null)particleSystem.transform.SetParent(null);
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
                if (collider != null) collider.enabled=false;
            Invoke("PlayParticle", 3f);
            Destroy(gameObject,3f);
            PlayAnimationByTrigger (AnimationType.DEATH);
        }
        public void PlayParticle()
        {
            if (particleSystem != null)  particleSystem.Play();
        }
        public void OnDamage(float f)
        {
           
            if (flashColor != null) flashColor.Flash();
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

        public void PlayAnimationByTrigger(AnimationType animationType)
        {
            animationBase.PlayAnimationByTrigger(animationType);
        }
        #endregion
        private void Update()
        {
            #region TESTE (ÁREA COMENTADA
            /*  */
            if (Input.GetKeyDown(KeyCode.T))
              {
                  OnDamage(10f);
                  Debug.Log(_currentLife);
              }
            #endregion
        }
        public void Damage(float damage)
        {
            OnDamage(damage);
        }
    }

}

