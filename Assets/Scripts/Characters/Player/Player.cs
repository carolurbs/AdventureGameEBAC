
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using Ebac.StateMachine;
using Clothes;

public class Player : Singleton<Player>
{
    public List<Collider> colliders;

    public List<FlashColor> flashColors;
    public HealthBase healthBase;
    public Animator animator;
    private bool jumping;
    public CharacterController characterController;
    public float speed = 1f;
    public float turnSpeed = 1f;
    public float gravity = -9.8f;
    public float jumpSpeed = 15f;
    public float vSpeed = 4f;
    public bool _alive = true;
    public Transform startposition;
    [Header("Run Setup")]
    public KeyCode keyRun = KeyCode.LeftShift;
    public float speedRun = 40f;
    public ClothesChange clothsChanger;
    public ClothType? activeClothType = null;
    public void Start()
    {
        transform.position = startposition.position;
        OnValidate();
        healthBase.OnKill += OnKill;
        Init();
    }
    public void OnValidate()
    {
        if (healthBase == null) healthBase = GetComponent<HealthBase>();    
    }

    public enum PlayerState
    {
        IDLE,
        WALKING,
        RUNNING,
        JUMPING,
        SHOOTING,
        DEAD
    }

    public StateMachine<PlayerState> stateMachine;
    public void Init()
    {
        stateMachine = new StateMachine<PlayerState>();
        stateMachine.Init();
        stateMachine.RegisteredStates(PlayerState.IDLE, new PlayerStates.PS_Idle());
        stateMachine.RegisteredStates(PlayerState.WALKING, new PlayerStates.PS_Walking());
        stateMachine.RegisteredStates(PlayerState.RUNNING, new PlayerStates.PS_Running());
        stateMachine.RegisteredStates(PlayerState.JUMPING, new PlayerStates.PS_Jumping());
        stateMachine.RegisteredStates(PlayerState.SHOOTING, new PlayerStates.PS_Shooting());
        stateMachine.RegisteredStates(PlayerState.DEAD, new PlayerStates.PS_Dead());

        stateMachine.SwitchState(PlayerState.IDLE);


    }
    public void InitGame()
    {

    }
    private void Update()
    {


        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime, 0);

        var inputAxisVertical = Input.GetAxis("Vertical");
        var speedVector = transform.forward * Input.GetAxis("Vertical") * speed;

        if (characterController.isGrounded)
        {
            if(jumping)
            {
               jumping=false;
                animator.SetTrigger("Land");
            }
            vSpeed = 0;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                vSpeed = jumpSpeed;
                animator.SetTrigger("Jump");
                if(!jumping)
                {
                    jumping = true;
                    animator.SetTrigger("Jump");
                }
            }
        }
        var isWalking = inputAxisVertical != 0;
        if (isWalking)
        {
            if (Input.GetKey(keyRun))
            {
                speedVector *= speedRun;
                animator.speed = speedRun;
            }
            else
            {
                animator.speed = 1;

            }
        }
        vSpeed -= gravity * Time.deltaTime;
        speedVector.y = vSpeed;
        characterController.Move(speedVector * Time.deltaTime);

        animator.SetBool("Run", isWalking);
    }
    #region LIFE
    /*public void Damage (HealthBase h)
    {
       Damage(h);

    }*/
    private void OnKill(HealthBase h)
    {
        if(_alive)
        {
            _alive = false;
            animator.SetTrigger("Death");
            colliders.ForEach(i=> i.enabled = false);
            Invoke(nameof(Revive), 3f);
        }
    }
    public void TurnOnColliders()
    {
        colliders.ForEach(i => i.enabled = true);

    }
    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Abism"))
        {
            transform.position = startposition.position;
            Debug.Log("Freefall");
        }
    }
        private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Enemy"))
        {
            flashColors.ForEach(i => i.Flash());
            VFXManager.Instance.ChangeVignette();
            ScreenShake.Instance.ShakeCamera();
            healthBase.Damage(5);
        }
    }
    #endregion
    [NaughtyAttributes.Button]
    public void Respawn()
    {
        if(CheckPointManager.Instance.HasCheckPoint())
        {
            transform.position=CheckPointManager.Instance.GetPositionToRespawn();
        }
    }
    private void Revive()
    {
        _alive=true;
        healthBase.ResetLife();
        animator.SetTrigger("Revive");
        Invoke(nameof(TurnOnColliders), 1f);
        Respawn();
       
    }
     public void ChangeSpeed(float speed, float duration)
    {
        StartCoroutine(ChangeSpeedCoroutine(speed, duration));
    }
    IEnumerator ChangeSpeedCoroutine(float localSpeed, float duration)
    {
        activeClothType = ClothType.SPEED;
        var defaultSpeed = speed;
        speed = localSpeed; 
        yield return new WaitForSeconds(duration);
        speed = defaultSpeed;
        activeClothType = null;
    }
    public void ChangeTexture(ClothesSetup setup, float duration )
    {
        StartCoroutine(ChangeTextureCoroutine(setup, duration));

    }
    IEnumerator ChangeTextureCoroutine(ClothesSetup setup, float duration)
    {
        activeClothType = ClothType.COLOR;
        clothsChanger.ChangeTexture(setup,duration);
        yield return new WaitForSeconds(duration);
       clothsChanger.ResetTexture();
        activeClothType=null;
    }
}
namespace PlayerStates
{

    public class PS_Idle : StateBase
    {
   
       
        
    }
    public class PS_Walking : StateBase
    {
       

    }

    public class PS_Running : StateBase
    {

    }

    public class PS_Jumping : StateBase
    {

    }

    public class PS_Shooting : StateBase
    {

    }
    public class PS_Dead : StateBase
    {

    }
}
