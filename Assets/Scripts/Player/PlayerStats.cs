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

    public static PlayerStats Instance
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

    private Dictionary<Stats, int> statsToValueDictionary =
        new Dictionary<Stats, int>();

    private StatsOranizer statsOrganizer;
    private VisualTextFeedbackSpawner visualTextFeedbackSpawner;

    private void Start()
    {
      statsOrganizer = GameAssets.StatsOrganizer.GetComponent<StatsOranizer>();
      visualTextFeedbackSpawner = FindObjectOfType<VisualTextFeedbackSpawner>();
      SetupStatDictionaryAllToZero();
      statsOrganizer.UpdateStatsUi(statsToValueDictionary);
    }


    private void Update() //testing purpose
    {
      if (Input.GetKeyDown(KeyCode.C))
      {
        UpdateOneStatByValue(Stats.Charisma, 20);
      }
    }

    private void SetupStatDictionaryAllToZero()
    {
      foreach (Stats statType in Enum.GetValues(typeof(Stats)))
      {
        if (!statsToValueDictionary.ContainsKey(statType))
        {
          statsToValueDictionary.Add(statType, 0);
        }
      }
    }

    // public void UpdateStatDictionary(
    //     Dictionary<Stats, int> statsChangeDictionary) //update statDictionary by adding another dictionary
    // {
    //   foreach (Stats stat in statsChangeDictionary)
    //   {
    //     statsToValueDictionary[stat] += stat.Value;
    //   }
    //
    //   statsOrganizer.UpdateStatsUi(statsToValueDictionary);
    //   //todo spawn visual feedback for each stat
    // }


    public void
      UpdateOneStatByValue(Stats stat, int valueToAdd)
      //sister method to UpdateStatDictionary; update only one entry of statDictionary
    {
      statsToValueDictionary[stat] += valueToAdd;
      statsOrganizer.UpdateStatsUi(statsToValueDictionary);

      visualTextFeedbackSpawner.SpawnStatsChangeVisualItem(stat.ToString(), valueToAdd);
    }


    //saving
    public object CaptureState()
    {
      return statsToValueDictionary;
    }

    public void RestoreState(object state)
    {
      statsToValueDictionary = (Dictionary<Stats, int>) state;
      // statsOrganizer.UpdateStatsUi(statsToValueDictionary);//todo fix this
    }
  }
}
