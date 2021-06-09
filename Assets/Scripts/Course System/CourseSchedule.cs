using System;
using Player;
using UnityEngine;

namespace Course_System
{
  public class CourseSchedule : MonoBehaviour
  {////this is just a place to store the schedule
   ///
   ///

   [Serializable]
   public struct OneClass {
     public CourseItem class1;
     public CourseItem class2;

   }
   [Header("First Year")]
   public OneClass[] y1day1 = new OneClass[2];
   public OneClass[] y1day2 = new OneClass[2];
   public OneClass[] y1day3 = new OneClass[2];
   [Header("First Year")]
   public OneClass[] y2day1 = new OneClass[2];
   public OneClass[] y2day2 = new OneClass[2];
   public OneClass[] y2day3 = new OneClass[2];

  }
}
