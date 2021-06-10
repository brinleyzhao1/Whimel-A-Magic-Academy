using System;
using System.Collections.Generic;
using Player;
using UnityEngine;

namespace Course_System
{
  public class CourseScheduleStorage : MonoBehaviour
  {////this is just a place to store the schedule
   ///
   ///
   ///
   #region Singleton

   private static CourseScheduleStorage _instance;

   public static CourseScheduleStorage Instance { get { return _instance; } }


   private void Awake()
   {
     if (_instance != null && _instance != this)
     {
       Destroy(this.gameObject);
     } else {
       _instance = this;
     }

     SetUpClassScheduleDictionary();
   }

   #endregion

   [Serializable]
   public struct OneClassIeOneTimePeriod {
     public CourseItem class1;
     public CourseItem class2;
   }

   public struct OneDay
   {
     public OneClassIeOneTimePeriod Morning;
     public OneClassIeOneTimePeriod Afternoon;
   }

   public struct OneYear
   {
     public OneDay Day1;
     public OneDay Day2;
     public OneDay Day3;
   }




   [Header("First Year")]
   // public OneDay[] year1 = new OneDay[3];
   // public OneYear year1;
   // public OneDay[] day1 = new OneDay[4];
   [SerializeField] private OneClassIeOneTimePeriod[] y1day1 = new OneClassIeOneTimePeriod[2];
   [SerializeField] private OneClassIeOneTimePeriod[] y1day2 = new OneClassIeOneTimePeriod[2];
   [SerializeField] private OneClassIeOneTimePeriod[] y1day3 = new OneClassIeOneTimePeriod[2];
   [Header("Second Year")]
   // public OneYear year2;
   [SerializeField] private OneClassIeOneTimePeriod[] y2day1 = new OneClassIeOneTimePeriod[2];
   [SerializeField] private OneClassIeOneTimePeriod[] y2day2 = new OneClassIeOneTimePeriod[2];
   [SerializeField] private OneClassIeOneTimePeriod[] y2day3 = new OneClassIeOneTimePeriod[2];


   public Dictionary<string, OneClassIeOneTimePeriod> yearDayTimeToClass = new Dictionary<string, OneClassIeOneTimePeriod>();


   private void SetUpClassScheduleDictionary()
   {
     //note be very careful not to make mistake here. there must be a better way but for now ill go with this
     yearDayTimeToClass["y1d1t0"] = y1day1[0];
     yearDayTimeToClass["y1d1t1"] = y1day1[1];

     yearDayTimeToClass["y1d2t0"] = y1day2[0];
     yearDayTimeToClass["y1d2t1"] = y1day2[1];

     yearDayTimeToClass["y1d3t0"] = y1day3[0];
     yearDayTimeToClass["y1d3t1"] = y1day3[1];

     yearDayTimeToClass["y2d1t0"] = y2day1[0];
     yearDayTimeToClass["y2d1t1"] = y2day1[1];

     yearDayTimeToClass["y2d2t0"] = y2day2[0];
     yearDayTimeToClass["y2d2t1"] = y2day2[1];

     yearDayTimeToClass["y2d3t0"] = y2day3[0];
     yearDayTimeToClass["y2d3t1"] = y2day3[1];

   }
  }
}
