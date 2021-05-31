using System;
using System.Collections.Generic;
using System.Linq;
using GameDev.tv_Assets.Scripts.Inventories;
using GameDevTV.Inventories;
using UnityEngine.UI;
using UnityEngine;

namespace Alchemy
{
  public class AlchemySystem : MonoBehaviour
  {

    List<InventoryItem> ingredients = new List<InventoryItem>();

    [SerializeField] private Transform ingredientTray;


    List<PotionRecipes> allRecipes = new List<PotionRecipes>();
    // private PotionRecipes[] allRecipes = new PotionRecipes[];

    private void Start()
    {
      allRecipes = Resources.LoadAll<PotionRecipes>("PotionRecipes").ToList();
    }



    public void AddIngredient(InventoryItem newIngredient)
    {
      //add to end of list
      //limit to 6
      if (ingredients.Count<6)
      {
        ingredients.Add(newIngredient);
      }

    }

    public void UpdateTrayUi()
    {
      for (int i = 0; i < ingredients.Count; i++)
      {
        Transform slot = ingredientTray.GetChild(i);
        Image slotImage = slot.GetChild(0).GetComponent<Image>();
        slotImage.enabled = true;
        slotImage.sprite = ingredients[i].GetIcon();
      }
    }

    public void ClearTray()
    {
      ingredients = new List<InventoryItem>();

      foreach (Transform traySlot in ingredientTray)
      {
        Image slotImage = traySlot.GetChild(0).GetComponent<Image>();
        slotImage.sprite = null;
        slotImage.enabled = false;
      }
    }


    public void MakePotion() // button
    {
      // HashSet<ActionItem> tray = ingredients.toset
      foreach (var recipe in allRecipes)
      {
        var difference1 = ingredients.Except(recipe.ingredients);
        var difference2 = recipe.ingredients.Except(ingredients);

        if (!difference1.Any() && !difference2.Any())
        {
          var player = GameObject.FindGameObjectWithTag("Player");
          var inventory = player.GetComponent<Inventory>();
          inventory.AddToFirstEmptySlot(recipe.finalPotion, 1);
        }
      }
      //print("oops no potion can be make"); //todo give a default potion
      ClearTray();



    }


  }
}
