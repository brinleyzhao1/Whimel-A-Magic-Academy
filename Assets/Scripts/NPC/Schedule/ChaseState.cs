using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaseState : StateMachineBehaviour
{
    public float repathTolerance = 2;
    public float repathCount = 10;
    public float runSpeed = 4;
    public static float chaseRadius = 10;
    PlayerExample target;
    NavMeshAgent navAgent;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
    {
        if (navAgent == null)
        {
            navAgent = animator.GetComponent<NavMeshAgent>();
        }

        if (target == null)
        {
            target = PlayerExample.GetInstance();
        }

        //Reset path upon entering chase state so we have a fresh one towards the target
        navAgent.ResetPath();
        navAgent.speed = runSpeed;
    }

    //If we don't need to stop chasing the player, set a new destination if the destination is too far from the player or we don't have a path
    public override void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!ShouldChasePlayer(animator.transform.position))
        {
            animator.SetInteger(IdleState.transitionParameter, (int)Transition.IDLE);
        }
        else
        {
            if (!navAgent.hasPath || (target.transform.position - navAgent.pathEndPosition).sqrMagnitude > repathTolerance * repathTolerance)
            {
                SetDestinationNearTarget(navAgent, target);
            }
        }
    }

    //Tries RepathCount times to find a path near the player, increasing the interactableRadius each time.
    //This is needed in case the player is not on valid Navmesh
    public void SetDestinationNearTarget(NavMeshAgent _agent, PlayerExample _target)
    {
        NavMeshHit hit;
        float radius = 0;
        for (int i = 0; i < repathCount; ++i)
        {
            Vector3 randomPosition = Random.insideUnitSphere * radius;
            randomPosition += _target.transform.position;
            if (NavMesh.SamplePosition(randomPosition, out hit, radius, 1))
            {
                _agent.SetDestination(hit.position);
                break;
            }
            else
            {
                ++radius;
            }
        }
    }


    //Check if we are within chase range of the target, is static to be used by other states
    public static bool ShouldChasePlayer(Vector3 _chaserPosition)
    {
        PlayerExample player = PlayerExample.GetInstance();
        return (player.transform.position - _chaserPosition).sqrMagnitude < chaseRadius * chaseRadius;
    }
}




