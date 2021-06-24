using System.Collections.Generic;
using GameDev.tv_Assets.Scripts.Saving;
using UnityEngine;

namespace Alchemy
{
  public class KnownPotionRecipesStorage : MonoBehaviour,ISaveable
  {
    #region Singleton

    private static KnownPotionRecipesStorage _instance;

    public static KnownPotionRecipesStorage Instance => _instance;


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


    [SerializeField]private List<PotionRecipeScriptableObject> knownPotionRecipes = new List<PotionRecipeScriptableObject>(20);



    public bool AlreadyKnownThisRecipe(PotionRecipeScriptableObject recipe)
    {
      print(recipe);
      print(knownPotionRecipes); //todo this is null
      if (knownPotionRecipes.Contains(recipe))
      {
        return true;
      }

      return false;
    }

    /// <summary>
    /// append new recipe, doesn't check if it's already contained
    /// </summary>
    /// <param name="newRecipe"></param>
    public void AddNewPotionRecipe(PotionRecipeScriptableObject newRecipe)
    {
      knownPotionRecipes.Add(newRecipe);
    }

    #region Saving

    public object CaptureState()
    {
      return knownPotionRecipes;
    }

    public void RestoreState(object state)
    {
      knownPotionRecipes = (List<PotionRecipeScriptableObject>) state;
    }

    #endregion
  }
}
