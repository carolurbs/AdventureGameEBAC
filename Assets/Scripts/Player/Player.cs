using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using Ebac.StateMachine;

public class Player :Singleton<Player>
{

    public Animator animator;
    public CharacterController characterController;
    public float speed =1f;
    public float turnSpeed =1f;
    public float gravity = -9.8f;
    public float jumpSpeed = 15f;
    public float vSpeed = 4f;
    [Header("Run Setup")]
    public KeyCode keyRun = KeyCode.LeftShift;
    public float speedRun = 40f;
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
    public void Start()
    {
        Init();
    }
    public void Init()
    {
        stateMachine = new StateMachine<PlayerState>();
        stateMachine.Init();
        stateMachine.RegisteredStates(PlayerState.IDLE, new PlayerStates.PS_Idle());
        stateMachine.RegisteredStates(PlayerState.WALKING,new PlayerStates.PS_Walking());
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
       
        
            transform.Rotate(0, Input.GetAxis("Horizontal") *turnSpeed * Time.deltaTime, 0);

            var inputAxisVertical = Input.GetAxis("Vertical");
            var speedVector = transform.forward * Input.GetAxis("Vertical") * speed;

            if(characterController.isGrounded)
              {
            vSpeed = 0;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                vSpeed = jumpSpeed;
            }
        }
        var isWalking = inputAxisVertical != 0;
        if(isWalking)
        {
            if(Input.GetKey(keyRun))
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
            characterController.Move(speedVector*Time.deltaTime);

            animator.SetBool("Run", isWalking);
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
