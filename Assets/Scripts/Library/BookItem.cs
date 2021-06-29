using System;
using GameDev.tv_Assets.Scripts.Inventories;
using Player;
using Skills;
using UnityEngine;

namespace Library
{
  [CreateAssetMenu(fileName = "FILENAME", menuName = "Items/Book Item", order = 0)]
  public class BookItem : InventoryItem
  {
  public int level = 1;

  public int timeNeedToRead = 5;//seconds
  //type: info (world building), potion, herb, etc

  [Header("Rewards")]
  public StatReward statReward1;
  public SkillExpReward expReward2;

  #region reward structs

   [Serializable]
    public class StatReward
    {
      [SerializeField] public Stats rewardStats;
      public int value;
    }

    [Serializable]
    public class SkillExpReward
    {
      [SerializeField] public SkillTypeEnum rewardSkill;
      public int expValue;
    }

  #endregion

  //reward
  }
}
