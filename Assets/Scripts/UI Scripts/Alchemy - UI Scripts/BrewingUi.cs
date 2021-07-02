using System.Collections;
using Alchemy;
using GameDev.tv_Assets.Scripts.UI.Inventories;
using Player;
using Player.Interaction;
using Skills;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Scripts
{
  public class BrewingUi : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI timeCountDownText;
    [SerializeField] private InventoryUi playerInventoryUi;


    [Header("ingredient slot UIs")] [SerializeField]
    private IngredientSlotUi ingredientSlot1;

    [SerializeField] private IngredientSlotUi ingredientSlot2;
    [SerializeField] private IngredientSlotUi ingredientSlot3;

    [SerializeField] private Button brewButton;

    private PotionRecipeScriptableObject thisRecipe = null;

    private bool haveAllIngredientsCanBrew;
    private bool inProcessOfBrewing;


    private void OnEnable()
    {
      thisRecipe = null;

      ClearOutBrewSectionUi();
    }



    /// <summary>
    /// when selected, update visual
    /// </summary>
    /// <param name="recipe"></param>
    public void UpdateDisplayedInfo(PotionRecipeScriptableObject recipe)
    {
      thisRecipe = recipe;

      titleText.text = recipe.GetDisplayName();
      descriptionText.text = recipe.GetDescription();
      timeCountDownText.text = recipe.timeNeedToBrew.ToString();

      //update ingredients list
      ingredientSlot1.UpdateIcon(recipe.ingredient1, recipe.quantity1);
      ingredientSlot2.UpdateIcon(recipe.ingredient2, recipe.quantity2);
      ingredientSlot3.UpdateIcon(recipe.ingredient3, recipe.quantity3);

      if (!CheckIfHaveAllIngredients(recipe))
      {
        brewButton.gameObject.GetComponent<Image>().color = Color.gray;
        haveAllIngredientsCanBrew = false;
      }
      else
      {
        brewButton.gameObject.GetComponent<Image>().color = Color.white;
        haveAllIngredientsCanBrew = true;
      }
    }


    public void ButtonBrew()
    {
      if (haveAllIngredientsCanBrew && !inProcessOfBrewing)
      {
        StartCoroutine(Brew());
      }
      else if (thisRecipe == null)
      {
        print("you dont have a recipe selected");
      }
      else
      {
        print("oops you don't have all the ingredients");
      }
    }



    #region Helper Functions

    private void ClearOutBrewSectionUi()
        {
          titleText.text = "";
          descriptionText.text = "";
          ingredientSlot1.UpdateIcon(null, 0);
          ingredientSlot2.UpdateIcon(null, 0);
          ingredientSlot3.UpdateIcon(null, 0);
          haveAllIngredientsCanBrew = false;
          brewButton.gameObject.GetComponent<Image>().color = Color.white;
        }

    IEnumerator Brew()
    {
      //wait some seconds / animation
      inProcessOfBrewing = true;
      yield return StartCoroutine(TimeManager.Instance.CountDownWithText(thisRecipe.timeNeedToBrew, timeCountDownText));

      //subtract all ingredients from inventory
      GameAssets.PlayerInventory.RemoveItemsFromInventory(thisRecipe.ingredient1, thisRecipe.quantity1);
      GameAssets.PlayerInventory.RemoveItemsFromInventory(thisRecipe.ingredient2, thisRecipe.quantity2);
      GameAssets.PlayerInventory.RemoveItemsFromInventory(thisRecipe.ingredient3, thisRecipe.quantity3);

      //add final potion to inventory
      GameAssets.PlayerInventory.AddToFirstEmptySlot(thisRecipe.finalPotion, 1);

      TimeManager.Instance.FastForwardByRealLifeSeconds(thisRecipe.timeNeedToBrew);

      UpdateDisplayedInfo(thisRecipe);

      if (playerInventoryUi.isActiveAndEnabled) //probably is not active
      {
         playerInventoryUi.Redraw();
      }

      //reward skill exp
      SkillProgression progression = PlayerSkills.Instance.skillProgression;
      int expGained = progression.expPerActivityAtLevel[thisRecipe.level];
      PlayerSkills.Instance.AddExperienceToSkill(SkillTypeEnum.Alchemy, expGained);


      //consume energy
      int energyConsumed = progression.energyConsumedPerActivityByLevel[thisRecipe.level];
      PlayerEnergy.Instance.UpdateEnergyByValue(-energyConsumed);

      inProcessOfBrewing = false;
    }


    private bool CheckIfHaveAllIngredients(PotionRecipeScriptableObject recipe)
    {
      int quantityRequired1 = recipe.quantity1;
      int quantityHave1 = GameAssets.PlayerInventory.TotalAmountHave(recipe.ingredient1);

      int quantityRequired2 = recipe.quantity2;
      int quantityHave2 = GameAssets.PlayerInventory.TotalAmountHave(recipe.ingredient2);

      int quantityRequired3 = recipe.quantity3;
      int quantityHave3 = GameAssets.PlayerInventory.TotalAmountHave(recipe.ingredient3);

      if (quantityRequired1 <= quantityHave1 && quantityRequired2 <= quantityHave2 &&
          quantityRequired3 <= quantityHave3)
      {
        return true;
      }

      return false;
    }


      #endregion


  }
}
