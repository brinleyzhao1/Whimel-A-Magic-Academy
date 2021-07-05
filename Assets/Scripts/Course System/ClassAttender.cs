using System;
using Player;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Course_System
{
  /// <summary>
  /// this script acts as an intermediate between time system and className attending ui.
  ///this script is triggered whenever it's className time, pulls the correct classes from courseSchedule,
  ///pull out ui to let player choose what classes they want to take and then execute its consequences
  /// </summary>
  public class ClassAttender : MonoBehaviour
  {
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





    public void GetTheTwoClassesForThisTime(int year, int day, int morningOrAfternoon) //called by time manager
    {
      //get the two classes from courseScheduleStorage
      string classCode = "y" + year + "d" + day + "t" + morningOrAfternoon;
      CourseItem firstClass = CourseScheduleStorage.Instance.yearDayTimeToClass[classCode].class1;
      CourseItem secondClass = CourseScheduleStorage.Instance.yearDayTimeToClass[classCode].class2;

      // currentTwoClasses[0] = firstClass;
      // currentTwoClasses[1] = secondClass;


      // ClassPanelUi classPanelUi = FindObjectOfType<ClassPanelUi>();
      // print(classPanelUi.name);
      Time.timeScale = 0;
      classPanelUi.gameObject.SetActive(true);
      classPanelUi.SetUpClassAttendingPanel(firstClass, secondClass);
    }


    public void ConfirmTakingClass(int currentClassNum)
    {
      if (currentClassNum == 0 ^ currentClassNum == 1)
      {
        //execute taking this className
        //todo coroutine time passes
        TimeManager.Hour += 3;

        CalculateStatChangeFromClassTaken(currentTwoClasses[currentClassNum]);
      }

      else if (currentClassNum == 2)
      {
        //actually skipping
      }
      else
      {
        Debug.LogError("a className num that's not 1, 2 has been provided, " + currentClassNum);
      }
    }


    private void CalculateStatChangeFromClassTaken(CourseItem className)
    {
      foreach (var oneStatIncreased in className.statsIncreased)
      {
        PlayerStats.Instance.UpdateOneStatByLevel(oneStatIncreased, className.classDifficultyLevel, true);
      }

      PlayerStats.Instance.UpdateOneStatByLevel(className.statDecreased, className.classDifficultyLevel, false);
    }


  }
}
