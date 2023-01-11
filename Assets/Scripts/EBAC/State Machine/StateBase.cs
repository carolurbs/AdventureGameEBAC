using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ebac.StateMachine
{

    public class StateBase
    {
        public virtual void OnStateEnter(object o = null)
        {
            Debug.Log("OnStateEnter");
        }
        public virtual void OnStateStay()
        {
            Debug.Log("OnStateStay");
        }
        public virtual void OnStateExit()
        {
            Debug.Log("OnStateExit");
        }
    }

    public class StateMenu : StateBase
    {
        public override void OnStateEnter(object o = null)
        {

        }
    }
    public class StatePlaying : StateBase
    {
        public override void OnStateEnter(object o = null)
        {
        }

    }
    public class StateResetPosition : StateBase
    {
        public override void OnStateEnter(object o = null)
        {

        }

    }


    public class StateEndGame : StateBase
    {
        public override void OnStateEnter(object o = null)
        {

        }
    }
}