using System;
using Player;
using UnityEngine;

namespace Course_System
{
  public class ClassAttender : MonoBehaviour
  {
    //this script acts as an intermediate between time system and class attending ui.
    //this script is triggered whenever it's class time, pulls the correct classes from courseSchedule,
    //pull out ui to let player choose what classes they want to take and then execute its consequences

    #region Singleton

    private static ClassAttender _instance;

    public static ClassAttender Instance
    {
      get { return _instance; }
    }


    private void Awake()
    {
      if (_instance != null && _instance != this)
      {
        Destroy(this.gameObject);
      }
      else
      {
        _instance = this;
      }
    }

    #endregion

    public ClassPanelUi classPanelUi;

    private readonly CourseItem[] currentTwoClasses = new CourseItem[2];
    // private CourseItem currentClass1;
    // private CourseItem currentClass2;


    private void Start()
    {
      //testing


      GetTheTwoClassesForThisTime(1, 1, 0);
      // print(GetTheTwoClassesForThisTime(1,1,1));
    }


    public void GetTheTwoClassesForThisTime(int year, int day, int morningOrAfternoon) //called by time manager
    {
      //get the two classes from courseScheduleStorage
      string classCode = "y" + year + "d" + day + "t" + morningOrAfternoon;
      CourseItem firstClass = CourseScheduleStorage.Instance.yearDayTimeToClass[classCode].class1;
      CourseItem secondClass = CourseScheduleStorage.Instance.yearDayTimeToClass[classCode].class2;

      currentTwoClasses[0] = firstClass;
      currentTwoClasses[1] = secondClass;

      // currentClass1 = firstClass;
      // currentClass2 = secondClass;

      // ClassPanelUi classPanelUi = FindObjectOfType<ClassPanelUi>();
      // print(classPanelUi.name);
      classPanelUi.gameObject.SetActive(true);
      classPanelUi.SetUpClassAttendingPanel(firstClass, secondClass);
    }



    public void ConfirmTakingClass(int currentClassNum)
    {
      if (currentClassNum == 1 ^ currentClassNum == 2)
      {
        //execute taking this class
        CalculateAllResultsFromClassTaken(currentTwoClasses[currentClassNum]);
        print("confirmed to take class "+ currentClassNum);
      }

      else if (currentClassNum == 3)
      {
        //actually skipping
      }
      else
      {
        Debug.LogError("a class num that's not 1, 2 has been provided, " + currentClassNum);
      }
    }

    private void CalculateAllResultsFromClassTaken(CourseItem className)
    {
      foreach (var oneStatChange in className.statsChange)
      {
        PlayerStats.Instance.UpdateOneStatByValue(oneStatChange.stat, oneStatChange.valueChange);
      }

      TimeManager.Hour += 4;
    }
  }
}
