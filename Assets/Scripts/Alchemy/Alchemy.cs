using System;
using System.Collections.Generic;
using System.Net;
using GameDev.tv_Assets.Scripts.Inventories;
using GameDev.tv_Assets.Scripts.Saving;
using Skills;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Alchemy
{
  /// <summary>
  /// the overall script overseeing Alchemy, also serve as Alchemy
  /// </summary>
  public class Alchemy : MonoBehaviour, ISaveable
  {
    #region Singleton

    private static Alchemy _instance;

    public static Alchemy Instance => _instance;


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

    [Header("Chance of Success")] [SerializeField]
    private float oneLevelAboveSuccessRate = .40f;
    [SerializeField] private float sameLevelSuccessRate = .70f;
    [SerializeField] private float oneLevelBelowSuccessRate = .80f;
    [SerializeField] private float twoLevelBelowSuccessRate = .90f;//a lower-leveled recipe

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

    public bool BrewSuccess(int recipeLevel)
    {
      int playerSkill = PlayerSkills.Instance.GetAlchemyLevel();

      float threshold = 1f;
      if (playerSkill == recipeLevel-1)
      {
         threshold = oneLevelAboveSuccessRate;
      }

      if (playerSkill == recipeLevel)
      {
         threshold = sameLevelSuccessRate;
      }

      if (playerSkill == recipeLevel+1)
      {
         threshold = oneLevelBelowSuccessRate;
      }

      if (playerSkill == recipeLevel+2)
      {
        threshold = twoLevelBelowSuccessRate;
      }

      print("success rate: " + threshold);
      return Random.value <= threshold;
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
      foreach (string id in (Array) state)
      {
        PotionRecipeScriptableObject item = InventoryItem.GetFromID(id) as PotionRecipeScriptableObject;
        restoreList.Add(item);
      }

      knownPotionRecipes = restoreList;
    }

    #endregion
  }
}
