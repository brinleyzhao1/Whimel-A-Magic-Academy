using UnityEngine;
using UnityEngine.AI;

namespace NPC
{
  public class NpcMover : MonoBehaviour
  {
    public GameObject characterDestination;
    private NavMeshAgent _agent;


    // Start is called before the first frame update
    void Start()
    {
      _agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
      _agent.SetDestination(characterDestination.transform.position);
    }
  }
}

