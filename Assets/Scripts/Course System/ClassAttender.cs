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

    private  CourseItem[] currentTwoClasses = new CourseItem[2];

    //Progression
   [SerializeField] private Range[] classDifficultyToStatRewardRange = new Range[3];
   [SerializeField] private int[] classDifficultyToEnergyConsumption = new int[3];


    [Serializable]
    public struct Range
    {
      //all inclusive
      public int min;
      public int max;
    }

    private void Start()
    {
      Checker();
    }

    public void GetTheTwoClassesForThisTime(int year, int day, int morningOrAfternoon) //called by time manager
    {
      //get the two classes from courseScheduleStorage
      string classCode = "y" + year + "d" + day + "t" + morningOrAfternoon;
      CourseItem firstClass = CourseScheduleStorage.Instance.yearDayTimeToClass[classCode].class1;
      CourseItem secondClass = CourseScheduleStorage.Instance.yearDayTimeToClass[classCode].class2;

      currentTwoClasses[0] = firstClass;
      currentTwoClasses[1] = secondClass;


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

        var thisClass = currentTwoClasses[currentClassNum];
        CalculateStatChange(thisClass);
        CalculateEnergyConsumption(thisClass);
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




    #region Private

    private void CalculateStatChange(CourseItem className)
    {
      int difficulty = className.classDifficultyLevel;
      foreach (var stat in className.statsIncreased)
      {
        int randomValue = Random.Range(classDifficultyToStatRewardRange[difficulty-1].min,classDifficultyToStatRewardRange[difficulty-1].max);
        PlayerStats.Instance.UpdateOneStatByValue(stat, randomValue);
      }
      int randomMinus = Random.Range(classDifficultyToStatRewardRange[difficulty-1].min,classDifficultyToStatRewardRange[difficulty-1].max);
      PlayerStats.Instance.UpdateOneStatByValue(className.statDecreased, randomMinus);

    }


    private void CalculateEnergyConsumption(CourseItem className)
    {
      int difficulty = className.classDifficultyLevel;
      int energyConsumed = classDifficultyToEnergyConsumption[difficulty - 1];
      PlayerEnergy.Instance.UpdateEnergyByValue(-energyConsumed);
    }

    private void Checker()
    {
      if (classDifficultyToStatRewardRange.Length == 0)
      {
        Debug.LogError("classDifficultyToStatRewardRange is unset");
      }

      if (classDifficultyToEnergyConsumption.Length == 0)
      {
        Debug.LogError("classDifficultyToEnergyConsumption is unset");
      }
    }

    #endregion




  }
}
