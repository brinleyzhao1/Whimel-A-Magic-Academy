using System.Collections.Generic;
using UnityEngine;

namespace Skills
{
  [CreateAssetMenu(fileName = "Progression", menuName = "Scriptables/New Progression", order = 0)]
  public class Progression : ScriptableObject
  {
    // public struct levelToExp
    // {
    //   public int level1;
    //   public int level2;
    // }
    [Tooltip("how much experience is required for each level. ignore level 0")]
    public int[] alchemyLevelProgression;


    // [SerializeField] ProgressionCharacterClass[] characterClasses = null;

    // Dictionary<CharacterClass, Dictionary<Stat, float[]>> lookupTable = null;

    public int[] GetProgressionForSkill(SkillTypeEnum skill)
    {
      if (skill == SkillTypeEnum.Alchemy)
      {
        return alchemyLevelProgression;
      }

      return alchemyLevelProgression;
    }

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
