using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnRollFin : StateMachineBehaviour
{
    public bool isFinished;

    public bool TimeToGivePlayerBackInput { get; internal set; }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        isFinished = true;
        TimeToGivePlayerBackInput = true;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.normalizedTime > 0.8f)
        {

            TimeToGivePlayerBackInput = true;
        }
      
    }

}
