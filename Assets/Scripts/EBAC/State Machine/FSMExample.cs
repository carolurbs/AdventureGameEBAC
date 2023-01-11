using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FSMExample : MonoBehaviour
{
    public enum ExampleEnum
    {
        STATE_ONE,
        STATE_TWO,
        STATE_THREE,
    }
    public StateMachine<ExampleEnum> stateMachine;

    private void Start()
    {
        stateMachine=new StateMachine<ExampleEnum>();
        stateMachine.Init();
        stateMachine.RegisteredStates(ExampleEnum.STATE_ONE, new StateBase());
        stateMachine.RegisteredStates(ExampleEnum.STATE_TWO, new StateBase());
        stateMachine.RegisteredStates(ExampleEnum.STATE_THREE, new StateBase());

    }
}
