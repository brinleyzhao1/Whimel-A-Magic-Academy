
using Endings;
using GameDev.tv_Assets.Scripts.Saving;
using NPC.Schedule;
using Player;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour, ISaveable
{

  [SerializeField] private int totalInGameYears = 3;

  private const int TimeScale = 800; //the bigger the faster in-game time is

  public TextMeshProUGUI yearText;
  public TextMeshProUGUI dayText;
  public TextMeshProUGUI clockText;

  public static int Minute, Hour, Day, Year=1;

  private static float _second;

  private PlayerEnergy _playerEnergy;

    void Start()
    {
      _playerEnergy = FindObjectOfType<PlayerEnergy>();
      clockText.text = "0:0";

    }

    // Update is called once per frame
    void Update()
    {
      CalculateTime();

    }


    private void UpdateText()
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
        UpdateHourOnNPCs();

        _playerEnergy.MinusEnergyPerHour();
      }
      else if (Hour >= 24)
      {
        Day++;
        Hour = Hour - 24; //for fast forward's sake
        UpdateText();
      }
      else if (Day > 14)
      {
        Year++;
        Day = 0;
        UpdateText();
      }
      else if (Year > totalInGameYears)
      {
        EndingDecider endingDecider = FindObjectOfType<EndingDecider>();
        endingDecider.GetEnding();
      }
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




    public object CaptureState()
    {
      return new int[] { Minute, Hour, Day, Year };

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
}
