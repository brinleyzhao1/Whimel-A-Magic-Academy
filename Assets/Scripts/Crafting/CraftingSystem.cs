using System;
using System.Collections.Generic;
using System.Linq;
using GameDev.tv_Assets.Scripts.Inventories;
using GameDevTV.Inventories;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Crafting
{
  public class CraftingSystem : MonoBehaviour
  {
    public enum CraftMode
    {
      Alchemy,
      Forge
    }

    public CraftMode alchemyOrForge;

    List<InventoryItem> ingredients = new List<InventoryItem>();

    [SerializeField] private Transform ingredientTray;

    List<Recipes> allRecipes = new List<Recipes>();




    // private Recipes[] allRecipes = new Recipes[];


    public void LoadInReceipes()
    {

      // print();
      if (alchemyOrForge == CraftMode.Alchemy)
      {
        allRecipes = Resources.LoadAll<Recipes>("Recipes/PotionRecipes").ToList();
      }

      if (alchemyOrForge == CraftMode.Forge)
      {
        allRecipes = Resources.LoadAll<Recipes>("Recipes/ForgeRecipes").ToList();
      }

      foreach (var receipe in allRecipes)
      {
        print(receipe);
      };
      // allRecipes = Resources.LoadAll<Recipes>("Recipes").ToList();
      // print(allRecipes.Count);
    }





    public void AddIngredientOnClick(InventoryItem newIngredient)
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

    public void SetProperTitle(CraftMode titleMode) //set from Forge/Alchemy Trigger
    {
      var title = transform.Find("Title");
      TMP_Text titleText = title.GetComponent<TextMeshProUGUI>();

      if (titleMode == CraftMode.Alchemy)
      {
        titleText.text = "Alchemy";
      }

      if (titleMode == CraftMode.Forge)
      {
        titleText.text = "Forge";
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
      // HashSet<ActionScriptableItem> tray = ingredients.toset
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
