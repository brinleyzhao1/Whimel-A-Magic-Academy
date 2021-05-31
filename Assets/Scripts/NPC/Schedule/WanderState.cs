using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WanderState : StateMachineBehaviour
{
  NavMeshAgent navAgent;
  public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
  {
    if (navAgent == null)
    {
      navAgent = animator.GetComponent<NavMeshAgent>();
    }
  }

  //If we should chase the player, go to chase state, if not and we don't have a path, go back to idle
  public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    if (ChaseState.ShouldChasePlayer(animator.transform.position))
    {
      animator.SetInteger(IdleState.transitionParameter, (int)Transition.CHASE);
    }
    else if (!navAgent.hasPath)
    {
      animator.SetInteger(IdleState.transitionParameter, (int)Transition.IDLE);
    }
  }
}
