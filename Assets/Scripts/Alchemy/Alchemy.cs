using System;
using System.Collections.Generic;
using System.Net;
using GameDev.tv_Assets.Scripts.Inventories;
using GameDev.tv_Assets.Scripts.Saving;
using Skills;
using Stats;
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
    [SerializeField] private float twoLevelBelowSuccessRate = .90f; //a lower-leveled recipe

    [Header("Dexterity")]
    [SerializeField]
    [Range(1, 1.05f)]
    [Tooltip("the higher dexterity, the exponential increase in success rate")]
    private float dexterityExponentialFactor = 1.05f;

    [SerializeField] [Range(20, 100f)] [Tooltip("divide from dexterity exponential")]
    private float dexterityDivisionFactor = 50f;

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

      float successRate = 1f;


      if (playerSkill == recipeLevel - 1)
      {
        successRate = oneLevelAboveSuccessRate;
      }

      if (playerSkill == recipeLevel)
      {
        successRate = sameLevelSuccessRate;
      }

      if (playerSkill == recipeLevel + 1)
      {
        successRate = oneLevelBelowSuccessRate;
      }

      if (playerSkill == recipeLevel + 2)
      {
        successRate = twoLevelBelowSuccessRate;
      }

      //dexterity
      float dexterityFactor = Mathf.Pow(dexterityExponentialFactor, PlayerStats.Instance.GetDexterity());
      successRate += dexterityFactor / dexterityDivisionFactor;

      print("success rate: " + successRate);
      return Random.value <= successRate;
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
