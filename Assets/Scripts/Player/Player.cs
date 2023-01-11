using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using Ebac.StateMachine;

public class Player :Singleton<Player>
{
   public enum PlayerState
    {
        WALKING,
        IDLE
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
        stateMachine.RegisteredStates(PlayerState.WALKING,new PSWalking());
        stateMachine.RegisteredStates(PlayerState.IDLE, new PSIdle());

        stateMachine.SwitchState(PlayerState.IDLE);
        
        
    }
    public void InitGame()
    {

    }

}
