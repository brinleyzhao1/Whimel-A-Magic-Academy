using System;
using System.Collections.Generic;
using GameDev.tv_Assets.Scripts.Inventories;
using UnityEngine;

namespace Alchemy
{
  // [Serializable]
  [CreateAssetMenu(fileName = "Potion Recipe", menuName = "Scriptables/Potion Recipe")]
  public class PotionRecipeScriptableObject : ActionScriptableItem
  {
    public ActionScriptableItem finalPotion;
    public int level; //should always be the same level as the finalPotion?
    public int timeNeedToBrew;

    

    [Header("Ingredients")] public ActionScriptableItem ingredient1;
    public int quantity1;
    public ActionScriptableItem ingredient2;
    public int quantity2;
    public ActionScriptableItem ingredient3;
    public int quantity3;


    /// <summary>
    /// Trigger the use of this item. Override to provide functionality.
    /// </summary>
    public override void Use(GameObject user)
    {
      Debug.Log("using potion recipe: " + this);
    }
  }
}
