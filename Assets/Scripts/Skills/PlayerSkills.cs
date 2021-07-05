using System;
using System.Collections.Generic;
using GameDev.tv_Assets.Scripts.Saving;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Skills
{
  /// <summary>
  /// keep record of what skills the player has and how much of each skill
  /// similar to playerStats
  /// </summary>
  public class PlayerSkills : MonoBehaviour, ISaveable
  {
    #region Singleton

    private static PlayerSkills _instance;

    public static PlayerSkills Instance
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

      skillsToValueDictionary[SkillTypeEnum.Alchemy] = alchemyStats;
      skillsToValueDictionary[SkillTypeEnum.Herbology] = herbologyStats;
    }

    #endregion

    public SkillProgression skillProgression = null;

    [Header("UI")] [SerializeField] private TextMeshProUGUI alchemyLevelText;

    [SerializeField] private Image alchemyFillBar;
    [SerializeField] private TextMeshProUGUI herbologyLevelText;
    [SerializeField] private Image herbologyFillBar;

    [System.Serializable]
    struct SkillStats
    {
      public int currentLevel;
      public int currentExperience;
    }

    private SkillStats alchemyStats = new SkillStats {currentLevel = 1, currentExperience = 0};
    private SkillStats herbologyStats = new SkillStats {currentLevel = 1, currentExperience = 0};

    private Dictionary<SkillTypeEnum, SkillStats> skillsToValueDictionary =
      new Dictionary<SkillTypeEnum, SkillStats>();


    private void Start()
    {
      UpdateSkillUi();
    }

    private void OnEnable()
    {
      UpdateSkillUi();
    }


    public void AddExperienceToSkill(SkillTypeEnum skill, int valueToAdd)
      //sister method to UpdateStatDictionary; update only one entry of statDictionary
    {
      SkillStats thisSkillStat = skillsToValueDictionary[skill];
      thisSkillStat.currentExperience = thisSkillStat.currentExperience + valueToAdd;
      skillsToValueDictionary[skill] = CheckIfLevelUpAndUpdate(skill, thisSkillStat);

      UpdateSkillUi();
    }


    public int  GetAlchemyLevel()
    {
      return alchemyStats.currentLevel;
    }
    private void Update() //testing purpose
    {
      if (Input.GetKeyDown(KeyCode.U))
      {
        AddExperienceToSkill(SkillTypeEnum.Alchemy, 20);
      }
    }

    // private void SetupSkillDictionaryAllToZero()
    // {
    //   foreach (SkillTypeEnum skillType in Enum.GetValues(typeof(SkillTypeEnum)))
    //   {
    //     if (!skillsToValueDictionary.ContainsKey(skillType))
    //     {
    //       SkillStats emptySkill = new SkillStats {currentLevel = 0, currentExperience = 0};
    //       skillsToValueDictionary.Add(skillType, emptySkill);
    //     }
    //   }
    // }

    // public void UpdateStatDictionary(
    //     Dictionary<StatsType, int> statsChangeDictionary) //update statDictionary by adding another dictionary
    // {
    //   foreach (StatsType statType in statsChangeDictionary)
    //   {
    //     skillsToValueDictionary[statType] += statType.Value;
    //   }
    //
    //   statsOrganizer.UpdateStatsUi(skillsToValueDictionary);
    //   //todo spawn visual feedback for each statType
    // }



    #region Private


    private SkillStats CheckIfLevelUpAndUpdate(SkillTypeEnum skill, SkillStats thisSkillStat)
    {
      // int[] experienceEachLevel = skillProgression.GetProgressionForSkill(skill);
      int[] experienceEachLevel = skillProgression.skillExperienceNeededToLevelUpTo;

      if (thisSkillStat.currentExperience > experienceEachLevel[thisSkillStat.currentLevel])
      {
        thisSkillStat.currentExperience -= experienceEachLevel[thisSkillStat.currentLevel];
        thisSkillStat.currentLevel += 1;
      }


      return thisSkillStat;
    }


    private void UpdateSkillUi()
        {
          //alchemy ui
          var currentAlchemyStats = skillsToValueDictionary[SkillTypeEnum.Alchemy];
          // alchemyLevelText.text = "Lvl. " + currentAlchemyStats.currentLevel;
          alchemyLevelText.text = skillProgression.rankNameByLevel[currentAlchemyStats.currentLevel];
          int[] alchemyExperienceEachLevel = skillProgression.skillExperienceNeededToLevelUpTo;
          int alchemyMaxExperienceThisLevel = alchemyExperienceEachLevel[currentAlchemyStats.currentLevel];
          alchemyFillBar.fillAmount = currentAlchemyStats.currentExperience / (float) alchemyMaxExperienceThisLevel;


          //herbology ui
          var currentHerbologyStats = skillsToValueDictionary[SkillTypeEnum.Herbology];
          herbologyLevelText.text = skillProgression.rankNameByLevel[currentHerbologyStats.currentLevel];
          int[] herbologyExperienceEachLevel = skillProgression.skillExperienceNeededToLevelUpTo;
          int herbologyMaxExperienceThisLevel = herbologyExperienceEachLevel[currentHerbologyStats.currentLevel];
          herbologyFillBar.fillAmount = currentHerbologyStats.currentExperience / (float) herbologyMaxExperienceThisLevel;
        }

    #endregion



    #region Saving

    public object CaptureState()
    {
      return skillsToValueDictionary;
    }

    public void RestoreState(object state)
    {
      skillsToValueDictionary = (Dictionary<SkillTypeEnum, SkillStats>) state;
      // statsOrganizer.UpdateStatsUi(skillsToValueDictionary);//todo fix this
    }

    #endregion
  }
}
