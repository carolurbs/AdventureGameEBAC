using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.Core.Singleton;
using Ebac.StateMachine;

public class GameManager : Singleton<GameManager>
{
   public enum GameStates
    {
        INTRO,
        GAMEPLAY,
        PAUSE,
        WIN,
        LOSE

    }
    public StateMachine<GameStates> stateMachine;
    public void Start()
    {
        Init();
    }
    public void Init()
    {
    stateMachine= new StateMachine<GameStates>();
    stateMachine.Init();
        stateMachine.RegisteredStates(GameStates.INTRO, new GMStateIntro());
        stateMachine.RegisteredStates(GameStates.GAMEPLAY, new StateBase());
        stateMachine.RegisteredStates(GameStates.PAUSE, new StateBase());
        stateMachine.RegisteredStates(GameStates.WIN, new StateBase());
        stateMachine.RegisteredStates(GameStates.LOSE, new StateBase());
        stateMachine.SwitchState(GameStates.INTRO);
    }
    public void InitGame()
    {

    }
}
