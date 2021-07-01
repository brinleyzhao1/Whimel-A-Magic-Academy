using System;
using System.Collections.Generic;
using GameDev.tv_Assets.Scripts.Saving;
using Player.Interaction;
using UI.StatsScripts;
using UnityEngine;

namespace Player
{
  public class PlayerStats : MonoBehaviour, ISaveable


  {
    #region Singleton

    private static PlayerStats _instance;

    public static PlayerStats Instance => _instance;


    private void Awake()
    {
      if (_instance != null && _instance != this)
      {
        Destroy(gameObject);
      }
      else
      {
        _instance = this;
      }
    }

    #endregion

    private Dictionary<StatsType, int> statsToValueDictionary =
      new Dictionary<StatsType, int>();

    private StatsOranizer statsOrganizer;
    private VisualTextFeedbackSpawner visualTextFeedbackSpawner;

    private void Start()
    {
      statsOrganizer = GameAssets.StatsOrganizer.GetComponent<StatsOranizer>();
      visualTextFeedbackSpawner = FindObjectOfType<VisualTextFeedbackSpawner>();
      SetupStatDictionaryAllToZero();
      statsOrganizer.UpdateStatsUi(statsToValueDictionary);
    }


    // private void Update() //testing purpose
    // {
    //   if (Input.GetKeyDown(KeyCode.C))
    //   {
    //     UpdateOneStatByValue(StatsType.Charisma, 20);
    //   }
    // }

    private void SetupStatDictionaryAllToZero()
    {
      foreach (StatsType statType in Enum.GetValues(typeof(StatsType)))
      {
        if (!statsToValueDictionary.ContainsKey(statType))
        {
          statsToValueDictionary.Add(statType, 0);
        }
      }
    }

    // public void UpdateStatDictionary(
    //     Dictionary<StatsType, int> statsChangeDictionary) //update statDictionary by adding another dictionary
    // {
    //   foreach (StatsType statType in statsChangeDictionary)
    //   {
    //     statsToValueDictionary[statType] += statType.Value;
    //   }
    //
    //   statsOrganizer.UpdateStatsUi(statsToValueDictionary);
    //   //todo spawn visual feedback for each statType
    // }


    public void
      UpdateOneStatByValue(StatsType statType, int valueToAdd)
      //sister method to UpdateStatDictionary; update only one entry of statDictionary
    {
      statsToValueDictionary[statType] += valueToAdd;
      statsOrganizer.UpdateStatsUi(statsToValueDictionary);

      visualTextFeedbackSpawner.SpawnStatsChangeVisualItem(statType.ToString(), valueToAdd);
    }


    #region Saving

    public object CaptureState()
    {
      return statsToValueDictionary;
    }

    public void RestoreState(object state)
    {
      statsToValueDictionary = (Dictionary<StatsType, int>) state;
      // statsOrganizer.UpdateStatsUi(statsToValueDictionary);//todo fix this
    }

    #endregion
  }
}
