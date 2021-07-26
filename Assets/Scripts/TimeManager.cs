using System;
using System.Collections;
using Control;
using Course_System;
using Endings;
using GameDev.tv_Assets.Scripts.Saving;
using NPC.Schedule;
using Player;
using Player.Interaction;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour, ISaveable
{
  #region Singleton

  private static TimeManager _instance;

  public static TimeManager Instance => _instance;


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


  [SerializeField] private int totalInGameYears = 3;
  [SerializeField] private int daysPerYear = 14;
  [SerializeField] private int minutesPerRealLifeSecond = 30;


  private const int TimeScale = 800; //the bigger the faster in-game time is

  public TextMeshProUGUI yearText;
  public TextMeshProUGUI dayText;
  public TextMeshProUGUI clockText;

  public static int Minute, Hour, Day=1, Year = 1;

  private static float _second;

  private PlayerEnergy _playerEnergy;

  public event Action NewSchoolYear;

  void Start()
  {
    _playerEnergy = FindObjectOfType<PlayerEnergy>();
    clockText.text = "0:0";

  }

  // Update is called once per frame
  void Update()
  {
    CalculateTime();


    if (Input.GetKeyDown(KeyCode.R))
    {
      Hour += 1;
    }
  }


  private void UpdateText() //todo: can probably replace with coroutine to improve performance
  {
    dayText.text = Day.ToString();
    clockText.text = Hour + ":" + Minute;
    yearText.text = Year.ToString();
  }

  private void CalculateTime()
  {
    _second += Time.deltaTime * TimeScale / 2;


    if (_second >= 60)
    {
      Minute++;
      _second = 0;
      UpdateText();
    }
    else if (Minute >= 60)
    {
      Hour++;
      Minute = 0;
      UpdateText();
      // UpdateHourOnNPCs();

      CheckIfIsClassTime();

      _playerEnergy.MinusEnergyPerHour();
    }
    else if (Hour >= 24)
    {
      Day++;
      Hour -= 24;
      UpdateText();
    }
    else if (Day > daysPerYear)
    {
      Year++;
      Day = 0;
      UpdateText();

      NewSchoolYear?.Invoke();
    }
    else if (Year > totalInGameYears)
    {
      EndingDecider endingDecider = FindObjectOfType<EndingDecider>();
      endingDecider.GetEnding();
    }

    BringOutTutorialOnceInBeginning(); //todo: no need to call this frequently
  }

  private static void BringOutTutorialOnceInBeginning()
  {
    if (Day == 1 && Year == 1 && Hour == 0 && Minute < 5)
    {
      GameAssets.TutorialPanel.SetActive(true);
      CursorChanger.Instance.OneMoreUiOut();
    }
  }

  private void CheckIfIsClassTime()
  {

    if (Hour == 8)
    {
      ClassAttender.Instance.GetTheTwoClassesForThisTime(Year, Day, 0);
    }

    if (Hour == 13)
    {
      ClassAttender.Instance.GetTheTwoClassesForThisTime(Year, Day, 1);
    }
  }


  public IEnumerator CountDownWithText(int timeLeft, TextMeshProUGUI timeCountDownText)
  {
    while (timeLeft > 0)
    {
      yield return new WaitForSeconds(1);
      timeLeft -= 1;
      timeCountDownText.text = timeLeft.ToString() + "s";
    }
  }

  public void FastForwardByRealLifeSeconds(int seconds) //todo: another method is to temporarily temper with timeRate
  {
    int inGameMinutesPassed = seconds * minutesPerRealLifeSecond;

    int min = Minute + inGameMinutesPassed;
    int hourDiff = Mathf.FloorToInt(min / 60);
    Hour += hourDiff;
    Minute = min % 60;
  }

  private void UpdateHourOnNPCs()
  {
    // BroadcastMessage("UpdateHo  ur", hour);
    var allNpcsNeedUpdateHour = FindObjectsOfType<SetHour>();
    foreach (var npcsNeedUpdateHour in allNpcsNeedUpdateHour)
    {
      npcsNeedUpdateHour.UpdateHour(Hour);
    }
  }


  #region Saving

  public object CaptureState()
  {
    return new int[] {Minute, Hour, Day, Year};
  }

  public void RestoreState(object state)
  {
    int[] data = (int[]) state;
    Minute = data[0];
    Hour = data[1];
    Day = data[2];
    Year = data[3];
    UpdateText();
  }

  #endregion


  // protected virtual void OnNewSchoolYear()
  // {
  //   NewSchoolYear?.Invoke();
  // }
}
