using System;
using UnityEngine;

namespace NPC.Schedule
{
  public class SetHour : MonoBehaviour
  {
    private Animator _animator;
    // private static readonly int Hour = Animator.StringToHash("hour");

    private void Start()
    {
      _animator = GetComponent<Animator>();
    }

    public void UpdateHour(int hour) //broad casted
    {
      // foreach (var i in _animator.)
      // {
        // print(i);
      // }

      // print(_animator.parameters);
      // _animator.SetInteger("hour", hour);
      // print(_animator.GetInteger(Hour));
    }

  }
}
