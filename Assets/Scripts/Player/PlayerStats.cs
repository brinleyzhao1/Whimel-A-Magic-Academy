using System;
using System.Collections.Generic;
using GameDev.tv_Assets.Scripts.Saving;
using GameDevTV.Saving;
using UI;
using UnityEngine;

namespace Player
{
  public class PlayerStats : MonoBehaviour, ISaveable

  {
    // string[] PieceTypeNames = System.Enum.GetNames (typeof(Stats));

    private Dictionary<string, int> statsDictionary = new Dictionary<string, int>();// note stats is referenced across using string, be cautious;
    [SerializeField] private StatsTabUI statsTabUi;

    private void Start()
  {
    // _statsTabUi = FindObjectOfType<StatsTabUI>(); //todo
    SetupStatDictionary();
    statsTabUi.UpdateStatsUi(statsDictionary);
  }

  private void SetupStatDictionary()
  {
    foreach (var statType in Enum.GetValues(typeof(Stats)))
    {
      if (!statsDictionary.ContainsKey(statType.ToString()))
      {
        statsDictionary.Add(statType.ToString(), 0);
      }
      // Stats.Add(statType.ToString(), 0);
    }
  }

  public void UpdateStatDictionary(Dictionary<string, int> statsChangeDictionary)
  {
    foreach (var stat in statsChangeDictionary)
    {
      statsDictionary[stat.Key] += stat.Value;
    }
    statsTabUi.UpdateStatsUi(statsDictionary);
  }



  public object CaptureState()
  {
    return statsDictionary;
  }

  public void RestoreState(object state)
  {
    statsDictionary = (Dictionary<string, int>) state;
    statsTabUi.UpdateStatsUi(statsDictionary);
  }
  }
}
