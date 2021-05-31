using System.Collections.Generic;
using GameDev.tv_Assets.Scripts.Inventories;
using UnityEngine;

namespace Crafting
{[CreateAssetMenu(fileName = "Recipes", menuName = "Recipes")]
  public class Recipes : ScriptableObject
  {
    public List<ActionItem> ingredients;

    public InventoryItem finalPotion;
  }
}
