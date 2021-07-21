using System;
using System.Collections.Generic;
using GameDev.tv_Assets.Scripts.Saving;
using Player;
using Stats;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Course_System
{
  /// <summary>
  /// this script acts as an intermediate between time system and thisClass attending ui.
  ///this script is triggered whenever it's thisClass time, pulls the correct classes from courseSchedule,
  ///pull out ui to let player choose what classes they want to take and then execute its consequences
  /// </summary>
  public class ClassAttender : MonoBehaviour, ISaveable
  {
    #region Singleton

    public static ClassAttender Instance { get; private set; }


    private void Awake()
    {
      if (Instance != null && Instance != this)
      {
        Destroy(this.gameObject);
      }
      else
      {
        Instance = this;
      }
    }

    #endregion

    public ClassPanelUi classPanelUi;

    private CourseItem[] currentTwoClasses = new CourseItem[2];

    //Progression
    [SerializeField] private Range[] classDifficultyToStatRewardRange = new Range[3];
    [SerializeField] private int[] classDifficultyToEnergyConsumption = new int[3];

    [Tooltip("number of additional attendances required to advance to next difficulty class")] [SerializeField]
    private int[] numberAttendanceToNextDifficulty = new int[3];


    private Dictionary<string, ClassStatus> classStatuses = new Dictionary<string, ClassStatus>(); //change to enum?


    [Serializable]
    public struct Range
    {
      //all inclusive
      public int min;
      public int max;
    }

    [Serializable]
    public struct ClassStatus
    {
      //all inclusive
      public int numberAttendance;
      public int difficulty; //1,2,3
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
        //execute taking this thisClass
        //todo coroutine time passes
        TimeManager.Hour += 3;

        var thisClass = currentTwoClasses[currentClassNum];
        RecordAttendance(thisClass);
        CalculateStatChange(thisClass);
        CalculateEnergyConsumption(thisClass);

      }

      else if (currentClassNum == 2)
      {
        //actually skipping
      }
      else
      {
        Debug.LogError("a thisClass num that's not 1, 2 has been provided, " + currentClassNum);
      }
    }


    #region Private

    private void CalculateStatChange(CourseItem thisClass)
    {
      int difficulty = classStatuses[thisClass.name].difficulty;
      foreach (var stat in thisClass.statsIncreased)
      {
        int randomValue = Random.Range(classDifficultyToStatRewardRange[difficulty - 1].min,
          classDifficultyToStatRewardRange[difficulty - 1].max);
        PlayerStats.Instance.UpdateOneStatByValue(stat, randomValue);
      }
      
      int randomMinus = Random.Range(classDifficultyToStatRewardRange[difficulty - 1].min,
        classDifficultyToStatRewardRange[difficulty - 1].max);
      PlayerStats.Instance.UpdateOneStatByValue(thisClass.statDecreased, randomMinus);

    }


    private void CalculateEnergyConsumption(CourseItem thisClass)
    {
      int difficulty = classStatuses[thisClass.name].difficulty;
      int energyConsumed = classDifficultyToEnergyConsumption[difficulty - 1];
      PlayerEnergy.Instance.UpdateEnergyByValue(-energyConsumed);
    }

    private void RecordAttendance(CourseItem thisClass)
    {
      if (!classStatuses.ContainsKey(thisClass.name))
      {
        var initialStatus = new ClassStatus {difficulty = 1, numberAttendance = 0};
        classStatuses[thisClass.name] = initialStatus;
      }

      var currentStatus = classStatuses[thisClass.name];

      currentStatus.numberAttendance += 1;

      //check if can advance
      int currentDifficulty = currentStatus.difficulty;
      int attendanceRequiredToAdvance = numberAttendanceToNextDifficulty[currentDifficulty - 1];
      if (currentStatus.numberAttendance >= attendanceRequiredToAdvance)
      {
        currentStatus.difficulty += 1;
        currentStatus.numberAttendance = 0;
      }

      classStatuses[thisClass.name] = currentStatus;
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


    #region Saving

    public object CaptureState()
    {
      return classStatuses;
    }

    public void RestoreState(object state)
    {
      classStatuses = (Dictionary<string, ClassStatus>) state;
    }

    #endregion
  }
}
