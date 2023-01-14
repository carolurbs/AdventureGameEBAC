using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using Ebac.StateMachine;

public class Player :Singleton<Player>
{
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

}
