using System.Collections;
using System.Collections.Generic;
using GameDev.tv_Assets.Scripts.Saving;
using GameDevTV.Saving;
using NPC.Schedule;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour, ISaveable
{

  private const int TimeScale = 800; //60

  public TextMeshProUGUI semesterText;
  public TextMeshProUGUI dayText;
  public TextMeshProUGUI clockText;

  public static int minute, hour, day, semester, year;

  private static float _second;

  private PlayerEnergy _playerEnergy;

  // Start is called before the first frame update
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
      dayText.text = day.ToString();
      clockText.text = hour + ":" + minute;

      if (semester == 0)
      {
        semesterText.text = "F";
      }
      else if (semester == 1)
      {
        semesterText.text = "S";
      }
    }
    private void CalculateTime()
    {
      _second += Time.deltaTime * TimeScale / 2;
      if (_second >= 60)
      {
        minute++;
        _second = 0;
        UpdateText();
      }
      else if (minute >= 60)
      {
        hour++;
        minute = 0;
        UpdateText();

        UpdateHourOnNPCs();

        _playerEnergy.MinusEnergyPerHour();
      }
      else if (hour >= 24)
      {
        day++;
        hour = hour - 24; //for fast forward's sake
        UpdateText();
      }
      else if (day > 14)
      {
        semester++;
        if (semester > 1)
        {
          semester = 0;
          year++;
        }
        day = 0;
        UpdateText();
      }
    }

    private void UpdateHourOnNPCs()
    {
      // BroadcastMessage("UpdateHo  ur", hour);
      var allNpcsNeedUpdateHour = FindObjectsOfType<SetHour>();
      foreach (var npcsNeedUpdateHour in allNpcsNeedUpdateHour)
      {
        npcsNeedUpdateHour.UpdateHour(hour);
      }
    }

    public object CaptureState()
    {
      return new int[] { minute, hour, day, semester, year };

    }

    public void RestoreState(object state)
    {
      int[] data = (int[]) state;
      minute = data[0];
      hour = data[1];
      day = data[2];
      semester = data[3];
      year = data[4];

    }
}
