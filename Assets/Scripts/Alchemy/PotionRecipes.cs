using System.Collections.Generic;
using GameDev.tv_Assets.Scripts.Inventories;
using UnityEngine;

namespace Alchemy
{[CreateAssetMenu(fileName = "Potion Recipes", menuName = "Recipes/Potion")]
  public class PotionRecipes : ScriptableObject
  {
    public List<ActionItem> ingredients;

    public ActionItem finalPotion;
  }
}
