using System;
using System.Collections.Generic;
using GameDev.tv_Assets.Scripts.Saving;
using Player.Interaction;
using UI_Scripts.StatsScripts;
using UI.StatsScripts;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Stats
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
    [SerializeField]  private VisualTextFeedbackSpawner visualTextFeedbackSpawner;


    private void Start()
    {
      statsOrganizer = GameAssets.StatsOrganizer.GetComponent<StatsOranizer>();
      SetupStatDictionaryAllToZero();
      statsOrganizer.UpdateStatsUi(statsToValueDictionary);
    }

    public int GetStamina()
    {
      return statsToValueDictionary[StatsType.Stamina];
    }

    private void Update() //testing purpose
    {
      if (Input.GetKeyDown(KeyCode.C))
      {
        UpdateOneStatByValue(StatsType.Stamina, 10);
      }
    }

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


    public void UpdateOneStatByValue(StatsType statType, int valueToAdd)
      //sister method to UpdateStatDictionary; update only one entry of statDictionary
    {
      statsToValueDictionary[statType] += valueToAdd;
      statsOrganizer.UpdateStatsUi(statsToValueDictionary);

visualTextFeedbackSpawner.gameObject.SetActive(true);
      visualTextFeedbackSpawner.SpawnStatsChangeVisualItem(statType.ToString(), valueToAdd);
    }

    /// <summary>
    /// return a random number within the range for the appropriate class level. an alternative method to get random
    /// </summary>
    /// <param name="classLevel"></param>
    /// <returns></returns>
    private int RandomChangeBaseOnClassLevel(int classLevel)
    {
      //todo more sophisticated random range?
      int min = classLevel * 2 - 1;
      int max = classLevel * 2 + 1;
      return Random.Range(min, max);
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
