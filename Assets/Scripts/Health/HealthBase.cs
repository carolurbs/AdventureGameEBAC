using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using AnimationManager;
public class HealthBase : MonoBehaviour
{
    public float startLife = 50f;
    public bool destroyOnKill = false; 
    public float _currentLife;
    public Action<HealthBase> OnDamage;
    public Action<HealthBase> OnKill;
    public Collider collider;
    public FlashColor flashColor;
    public bool lookAtPlayer = false;
    public ParticleSystem particleSystem;
    [Header(" Animation")]
    [SerializeField] public AnimationBase animationBase;
    public float startAnimationDuration = .2f;
    public Ease startAnimationEase = Ease.OutBack;
    public bool startwithBornAnimation = true;
    private Player _player;
    private void Awake()
    {
        if (particleSystem != null) particleSystem.transform.SetParent(null);

        Init();
    }
    public void Start()
    {
        _player = GameObject.FindObjectOfType<Player>();
    }
    protected virtual void Init()
    {
        ResetLife();
        if (startwithBornAnimation)
            BornAnimation();
    }

    public void ResetLife()
    {
       
        _currentLife = startLife;
    }
    public virtual void Kill()

    {
        if (destroyOnKill)
            Destroy(gameObject, 3f);

        OnKill?.Invoke(this);
        if (collider != null) collider.enabled = false;
        Invoke("PlayParticle", 3f);
        PlayAnimationByTrigger(AnimationType.DEATH);

    }
    public void PlayParticle()
    {
        if (particleSystem != null) particleSystem.Play();
    }
    [NaughtyAttributes.Button]
   public void Damage()
    {
        Damage(5);
    }
    public void Damage(float f)
    {
        if (flashColor != null) flashColor.Flash();

        _currentLife = -f;
        if (_currentLife <= 0)
        {
            Kill();
        }
        OnDamage?.Invoke(this);

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
    private void OnCollisionEnter(Collision collision)
    {
        Player p = collision.transform.GetComponent<Player>();
        if (p != null)
        {
            p.Damage(1);
        }

    }

    public virtual void Update()
    {
        if (lookAtPlayer)
        {
            transform.LookAt(_player.transform.position);
        }
    }
}
