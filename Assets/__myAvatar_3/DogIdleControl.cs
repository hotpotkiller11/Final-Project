using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogIdleControl : StateMachineBehaviour
{
    public int numOfState = 2;
    public float minNormTime = 0f;
    public float maxNormTime = 40f;

    protected float m_RandomNormTime;
    readonly int m_HashRandomIdle = Animator.StringToHash("RandomIdle");
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        m_RandomNormTime = Random.Range(minNormTime, maxNormTime);
        //Debug.Log("this is the random base idle time result"+m_RandomNormTime);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (animator.IsInTransition(0) && animator.GetCurrentAnimatorStateInfo(0).fullPathHash == stateInfo.fullPathHash)
        {
            animator.SetInteger(m_HashRandomIdle, -1);
        }//动画离开0时，将RandomIdle设置回-1，以方便下次进入这个状态时使用 

        if (stateInfo.normalizedTime > m_RandomNormTime && !animator.IsInTransition(0))
        {
            animator.SetInteger(m_HashRandomIdle, Random.Range(0, numOfState));
            //Debug.Log("time out change state");
        }// 在0待的时间>随机的维持时间，随机一个值，切换到其他的WAIT状态。 
    }
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
