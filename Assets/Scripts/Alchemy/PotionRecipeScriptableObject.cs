
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
    public List<ActionScriptableItem> ingredients;

    public ActionScriptableItem finalPotion;

    /// <summary>
    /// Trigger the use of this item. Override to provide functionality.
    /// </summary>
    public override void Use(GameObject user)
    {
      Debug.Log("using potion recipe: " + this);

    }
  }
}
