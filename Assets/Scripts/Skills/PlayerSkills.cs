using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
  /// <summary>
  /// keep record of what skills the player has and how much of each skill
  /// similar to playerStats
  /// </summary>
  public class PlayerSkills : MonoBehaviour
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

    [SerializeField] Progression progression = null;

    struct SkillStats
    {
      public int CurrentLevel;
      public int CurrentExperience;
    }

    private SkillStats alchemyStats = new SkillStats {CurrentLevel = 1, CurrentExperience = 0};
    private SkillStats herbologyStats = new SkillStats {CurrentLevel = 1, CurrentExperience = 0};

    private Dictionary<SkillTypeEnum, SkillStats> skillsToValueDictionary =
      new Dictionary<SkillTypeEnum, SkillStats>(); // note skill is referenced across using string, be cautious;

    // private StatsOranizer statsOrganizer;


    private void Start()
    {
      // statsOrganizer = GameAssets.StatsOrganizer.GetComponent<StatsOranizer>();
      // SetupSkillDictionaryAllToZero();
      // statsOrganizer.UpdateStatsUi(skillsToValueDictionary);
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
    //     Dictionary<Stats, int> statsChangeDictionary) //update statDictionary by adding another dictionary
    // {
    //   foreach (Stats stat in statsChangeDictionary)
    //   {
    //     skillsToValueDictionary[stat] += stat.Value;
    //   }
    //
    //   statsOrganizer.UpdateStatsUi(skillsToValueDictionary);
    //   //todo spawn visual feedback for each stat
    // }


    public void AddExperienceToSkill(SkillTypeEnum skill, int valueToAdd)
      //sister method to UpdateStatDictionary; update only one entry of statDictionary
    {
      SkillStats thisSkillStat = skillsToValueDictionary[skill];
      thisSkillStat.CurrentExperience = thisSkillStat.CurrentExperience  + valueToAdd;
      skillsToValueDictionary[skill] = CheckIfLevelUpAndUpdate(skill, thisSkillStat);

      //todo update UI
      // statsOrganizer.UpdateStatsUi(skillsToValueDictionary);
    }

    private SkillStats CheckIfLevelUpAndUpdate(SkillTypeEnum skill, SkillStats thisSkillStat)
    {
      int[] experienceEachLevel = progression.GetProgressionForSkill(skill);

      if (thisSkillStat.CurrentExperience > experienceEachLevel[thisSkillStat.CurrentLevel])
      {
        thisSkillStat.CurrentExperience -= experienceEachLevel[thisSkillStat.CurrentLevel];
        thisSkillStat.CurrentLevel += 1;

      }
      return thisSkillStat;
    }

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
