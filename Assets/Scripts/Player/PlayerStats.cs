using System;
using System.Collections.Generic;
using GameDev.tv_Assets.Scripts.Saving;
using UI;
using UI.StatsScripts;
using UnityEngine;

namespace Player
{
  public class PlayerStats : MonoBehaviour, ISaveable

  {

    private Dictionary<string, int> statsToValueDictionary = new Dictionary<string, int>();// note stats is referenced across using string, be cautious;
    private StatsTabUi statsTabUi;
     private VisualTextFeedbackSpawner visualTextFeedbackSpawner;

    private void Start()
  {
    statsTabUi = FindObjectOfType<StatsTabUi>(); //todo
    visualTextFeedbackSpawner = FindObjectOfType<VisualTextFeedbackSpawner>();
    SetupStatDictionaryAllToZero();
    statsTabUi.UpdateStatsUi(statsToValueDictionary);
  }


    private void Update() //testing purpose
    {
      if (Input.GetKeyDown(KeyCode.C))
      {
        UpdateOneStatByValue("Courage", 20);
      }
    }

    private void SetupStatDictionaryAllToZero()
  {
    foreach (var statType in Enum.GetValues(typeof(Stats)))
    {
      if (!statsToValueDictionary.ContainsKey(statType.ToString()))
      {
        statsToValueDictionary.Add(statType.ToString(), 0);
      }
    }
  }

  public void UpdateStatDictionary(Dictionary<string, int> statsChangeDictionary) //update statDictionary by adding another dictionary
  {
    foreach (var stat in statsChangeDictionary)
    {
      statsToValueDictionary[stat.Key] += stat.Value;
    }
    statsTabUi.UpdateStatsUi(statsToValueDictionary);
    //todo spawn visual feedback for each stat
  }


  public void UpdateOneStatByValue(string stat, int valueToAdd) //sister method to UpdateStatDictionary; update only one entry of statDictionary
  {
    statsToValueDictionary[stat] += valueToAdd;
    statsTabUi.UpdateStatsUi(statsToValueDictionary);

    visualTextFeedbackSpawner.SpawnStatsChangeVisualItem(stat, valueToAdd);
  }


  //saving
  public object CaptureState()
  {
    return statsToValueDictionary;
  }

  public void RestoreState(object state)
  {
    statsToValueDictionary = (Dictionary<string, int>) state;
    statsTabUi.UpdateStatsUi(statsToValueDictionary);
  }
  }
}
