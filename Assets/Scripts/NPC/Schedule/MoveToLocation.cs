using UnityEngine;
using UnityEngine.AI;

namespace NPC.Schedule
{
  public class MoveToLocation : StateMachineBehaviour
  {

    [SerializeField] private GameObject characterDestination;

    // [SerializeField] private Vector3 location;
    NavMeshAgent _navAgent;
    private Animator _animator;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      if (_navAgent == null)
      {
        _navAgent = animator.GetComponent<NavMeshAgent>();
      }

      // _navAgent.SetDestination(location);
      _navAgent.SetDestination(characterDestination.transform.position);

    }
  }
}
