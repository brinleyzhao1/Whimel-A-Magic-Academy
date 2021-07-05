using System;
using System.Collections.Generic;
using GameDev.tv_Assets.Scripts.Saving;
using Player.Interaction;
using Stats;
using UI_Scripts.StatsScripts;
using UI.StatsScripts;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

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
    [SerializeField]  private VisualTextFeedbackSpawner visualTextFeedbackSpawner;

    public Range[] classLevelToStatRewardRange;

    [Serializable]
    public struct Range
    {
      //all inclusive
      public int min;
      public int max;
    }

    private void Start()
    {
      statsOrganizer = GameAssets.StatsOrganizer.GetComponent<StatsOranizer>();
      SetupStatDictionaryAllToZero();
      statsOrganizer.UpdateStatsUi(statsToValueDictionary);
    }


    // private void Update() //testing purpose
    // {
    //   if (Input.GetKeyDown(KeyCode.C))
    //   {
    //     UpdateOneStatByLevel(StatsType.Charisma, 20);
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
      UpdateOneStatByLevel(StatsType statType, int level, bool add)
      //sister method to UpdateStatDictionary; update only one entry of statDictionary
    {
      //todo: a little dropdown animation
      // visualFeedbackBoard.GetComponent<Image>().IsActive(true);


      int randomValue = Random.Range(classLevelToStatRewardRange[level].min,classLevelToStatRewardRange[level].max);
      if (!add)
        randomValue *= -1;

      UpdateOneStatByValue(statType, randomValue);
    }

    private void UpdateOneStatByValue(StatsType statType, int valueToAdd)
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
