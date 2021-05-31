using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Course_System;
using Endings;
using UnityEngine;

/// <summary>
/// should sit on course selection menu
/// </summary>
public class CourseCart : MonoBehaviour
{
  [SerializeField] private List<EndingItem> _unpaidCourses = new List<EndingItem>();

  private CourseTranscript _courseTranscript;

  private void Start()
  {
    _courseTranscript = FindObjectOfType<CourseTranscript>();
  }


  public void UpdateCart(int slot, EndingItem ending)
  {
    _unpaidCourses[slot] = ending;
  }



  public void ConfirmPay() //to be used by confirm button
  {
    _courseTranscript.AddNewSemesterCourses(_unpaidCourses);
  }
}
