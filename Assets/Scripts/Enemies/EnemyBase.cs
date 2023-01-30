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
        public HealthBase healthBase;
        public  FlashColor flashColor; 
        public float startLife=10f;
        public float _currentLife;
        public bool lookAtPlayer=false;
        public ParticleSystem particleSystem;
        [Header(" Animation")]
        [SerializeField]public AnimationBase animationBase;
        public float startAnimationDuration = .2f;
        public Ease startAnimationEase = Ease.OutBack;
        public bool startwithBornAnimation=true;
        private Player _player;
        private void Awake()
        {
            if(particleSystem!=null)particleSystem.transform.SetParent(null);
        }
        public void InitEnemy()

        {
             Init();
        }
        public void Start()
        {
            _player = GameObject.FindObjectOfType<Player>();
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
            transform.position -= transform.forward;
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
      
        public void Damage(float damage)
        {
            OnDamage(damage);
        }
        public void Damage(float damage,Vector3 dir)
        {
            //OnDamage(damage);
            transform.DOMove(transform.position - dir, .1f);

        }
      

        public virtual void Update()
        {
            if (lookAtPlayer)
            {
                transform.LookAt(_player.transform.position);
            }
        }
    }

}

