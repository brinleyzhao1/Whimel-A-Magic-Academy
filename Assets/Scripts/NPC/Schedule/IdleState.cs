using UnityEngine;
using UnityEngine.AI;

//Move this to definition file
public enum Transition
{
  IDLE,
  WANDER,
  CHASE
}

public class IdleState : StateMachineBehaviour
{
  //Move this to definition file
  public const string transitionParameter = "State";

  NavMeshAgent navAgent;
  public float minWanderDistance = 5;
  public float maxWanderDistance = 15;
  public float walkSpeed = 1;

  public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  {
    if (navAgent == null)
    {
      navAgent = animator.GetComponent<NavMeshAgent>();
    }

    navAgent.ResetPath();
    navAgent.speed = walkSpeed;
  }

  //Check if we should chase the player, if not - Set a random destination if we don't already have one
  // public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
  // {
  //   if (ChaseState.ShouldChasePlayer(animator.transform.position))
  //   {
  //     animator.SetInteger(transitionParameter, (int)Transition.CHASE);
  //   }
  //   else
  //   {
  //     if (navAgent.hasPath)
  //     {
  //       animator.SetInteger(transitionParameter, (int)Transition.WANDER);
  //     }
  //     else
  //     {
  //       SetRandomDestination(navAgent);
  //     }
  //   }
  // }

  //Function to set a random destination on Navmesh
  public void SetRandomDestination(NavMeshAgent _agent)
  {
    float radius = Random.Range(minWanderDistance, maxWanderDistance);
    Vector3 randomPosition = Random.insideUnitSphere * radius;
    randomPosition += _agent.transform.position;
    NavMeshHit hit;
    if (NavMesh.SamplePosition(randomPosition, out hit, radius, 1))
    {
      _agent.SetDestination(hit.position);
    }
  }
}
