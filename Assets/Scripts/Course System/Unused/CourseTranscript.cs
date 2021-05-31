using System;
using System.Collections;
using System.Collections.Generic;
using Course_System;
using Endings;
using GameDev.tv_Assets.Scripts.Saving;
using GameDevTV.Saving;
using UnityEngine;

public class CourseTranscript : MonoBehaviour, ISaveable
{
   private List<EndingItem> allTakenCourses = new List<EndingItem>();
   [SerializeField] EndingItem[] allCourses;

  private void Awake()
  {
    allCourses = Resources.LoadAll<EndingItem>("Courses");
  }

  public void AddNewSemesterCourses(List<EndingItem> courseList)
  {
    //
  }


  // public List<CourseItem> CalculateThisSemesterCatalog(int semesterIndex, int slotIndex)
  // {
  //   if (allCourses.Length == 0)
  //   {
  //     allCourses = Resources.LoadAll<CourseItem>("Courses");
  //     print("reloaded");
  //   }
  //
  //   List<CourseItem> result = new List<CourseItem>();
  //   foreach (var candidate in allCourses)
  //   {
  //     //condition 1: offered
  //     if (semesterIndex == 0 && !candidate.fallTimeSlot[slotIndex]) //fall
  //     {
  //         continue;
  //     }
  //     else if (semesterIndex == 1 && !candidate.springTimeSlot[slotIndex]) //spring
  //     {
  //         continue;
  //     }
  //
  //
  //     //condition 2: satisfy prereq
  //     foreach (var preReq in candidate.preReq)
  //     {
  //       if (!allTakenCourses.Contains(preReq))
  //       {
  //         continue;
  //       }
  //     }
  //
  //     result.Add(candidate);
  //   }
  //
  //   return result;
  // }


  public object CaptureState()
  {
    return allTakenCourses;
  }

  public void RestoreState(object state)
  {
    // var allTakenCourses = (List<CourseItem>)state;
    // for (int i = 0; i < inventorySize; i++)
    // {
    //   slots[i] = CourseItem.GetFromID(slotStrings[i]);
    // }
    // if (inventoryUpdated != null)
    // {
    //   inventoryUpdated();
    return;
  }
}
