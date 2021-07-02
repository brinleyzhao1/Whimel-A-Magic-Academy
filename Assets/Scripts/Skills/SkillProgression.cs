using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
  /// <summary>
  /// A script to store info and govern the level system of skills
  ///
  ///  Level up by gaining exp (from performing activities in that discipline and sometimes from reading books and attending classes).
  ///Determines which potion / plants can players interact with (perform activity).
  /// Brewing higher level potion / growing higher level plants also gives higher rewards.
  /// </summary>
  public class SkillProgression : MonoBehaviour
  {
    // public struct levelToExp
    // {
    //   public int level1;
    //   public int level2;
    // }
    [Tooltip("how much experience is required for each level. ignore level 0")]
    public int[] skillExperienceNeededToLevelUpTo = new int[8];

    [Tooltip("how much energy is consumed when player performs an activity of that level. ignore level 0")]
    public int[] energyConsumedPerActivityByLevel = new int[8]; //ignore element 0

    [Tooltip("how much experience is awarded when player performs an activity of that level. ignore level 0")]
    public int[] expPerActivityAtLevel = new int[8]; //ignore element 0


    public readonly string[] rankNameByLevel = new string[]
    {
      "Ignore Me",
      "Introductory",
      "Beginner",
      "Basic",
      "Proficient",
      "Skilled",
      "Master",
      "Legend"
    };


    // [SerializeField] ProgressionCharacterClass[] characterClasses = null;

    // Dictionary<CharacterClass, Dictionary<Stat, float[]>> lookupTable = null;


    // public float GetStat(Stat statType, CharacterClass characterClass, int level)
    // {
    //     BuildLookup();
    //
    //     if (!lookupTable[characterClass].ContainsKey(statType))
    //     {
    //         return 0;
    //     }
    //
    //     float[] levels = lookupTable[characterClass][statType];
    //
    //     if (levels.Length == 0)
    //     {
    //         return 0;
    //     }
    //
    //     if (levels.Length < level)
    //     {
    //         return levels[levels.Length - 1];
    //     }
    //
    //     return levels[level - 1];
    // }
    //
    // public int GetLevels(Stat statType, CharacterClass characterClass)
    // {
    //     BuildLookup();
    //
    //     float[] levels = lookupTable[characterClass][statType];
    //     return levels.Length;
    // }
    //
    // private void BuildLookup()
    // {
    //     if (lookupTable != null) return;
    //
    //     lookupTable = new Dictionary<CharacterClass, Dictionary<Stat, float[]>>();
    //
    //     foreach (ProgressionCharacterClass progressionClass in characterClasses)
    //     {
    //         var statLookupTable = new Dictionary<Stat, float[]>();
    //
    //         foreach (ProgressionStat progressionStat in progressionClass.stats)
    //         {
    //             statLookupTable[progressionStat.statType] = progressionStat.levels;
    //         }
    //
    //         lookupTable[progressionClass.characterClass] = statLookupTable;
    //     }
    // }
    //
    // [System.Serializable]
    // class ProgressionCharacterClass
    // {
    //     public CharacterClass characterClass;
    //     public ProgressionStat[] stats;
    // }
    //
    // [System.Serializable]
    // class ProgressionStat
    // {
    //     public Stat statType;
    //     public float[] levels;
    // }
  }
}
