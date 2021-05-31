using System;
using UnityEngine;
using UnityEngine.AI;
namespace NPC.Schedule
{
  /// <summary>
  /// A ScriptableObject that represents a period of event that an NPC does
  /// </summary>
  // [CreateAssetMenu(fileName = "schedule event", menuName = "schedule event")]
  public class ScheduleActivity : ScriptableObject

  //task = ScheduleActivity
  {

    public int startTime;

    // public ScheduleActivityType type;
    [HideInInspector] public Animator animator;
    [HideInInspector] public NavMeshAgent agent;


    public virtual void StartTask() {
      // if (type == ScheduleActivityType.Idle)
      // {
      //   animator.SetFloat("forwardSpeed", 0);
      // }

      Debug.Log("ScheduleActivity started: " + this.name);
    }



    // void Start()
    // {
    //   // _agent = GetComponent<NavMeshAgent>();
    // }
    //
    // // Update is called once per frame
    // void Update()
    // {
    //   // _agent.SetDestination(characterDestination.transform.position);
    // }

  }


  // public enum ScheduleActivityType
  // {
  //   Idle,
  //   Sleep,
  //   WalkToDestination
  // }
}
