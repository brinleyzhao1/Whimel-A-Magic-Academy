using System;
using System.Collections.Generic;
using GameDev.tv_Assets.Scripts.Inventories;
using GameDev.tv_Assets.Scripts.Saving;
using UnityEditor;
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


    public List<PotionRecipeScriptableObject> knownPotionRecipes = new List<PotionRecipeScriptableObject>(20);


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
//todo cannot seriliaze a list
    public object CaptureState()
    {
      //convert to an array of id for storage
      List<string> listOfKnownIds = new List<string>();
      foreach (var recipeObject in knownPotionRecipes)
      {
        listOfKnownIds.Add(recipeObject.GetItemID());
      }

      var arrayKnownRecipes = listOfKnownIds.ToArray();
      return arrayKnownRecipes;
    }

    public void RestoreState(object state)
    {
      var restoreList = new List<PotionRecipeScriptableObject>();
      foreach (string id in (Array)state)
      {
        PotionRecipeScriptableObject item = InventoryItem.GetFromID(id) as PotionRecipeScriptableObject;
        restoreList.Add(item);
      }
      knownPotionRecipes = restoreList;
    }

    #endregion
  }
}
