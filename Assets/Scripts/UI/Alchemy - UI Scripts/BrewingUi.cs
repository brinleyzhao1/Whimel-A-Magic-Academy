using Alchemy;
using TMPro;
using UnityEngine;

namespace UI
{
  public class BrewingUi : MonoBehaviour
  {

    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;


    [Header("ingredient slot UIs")]
    [SerializeField] private IngredientSlotUi ingredientSlot1;
    [SerializeField] private IngredientSlotUi ingredientSlot2;
    [SerializeField] private IngredientSlotUi ingredientSlot3;

    // [SerializeField] private

    //when selected, update visual
    public void UpdateDisplayedInfo(PotionRecipeScriptableObject recipe)
    {
      titleText.text = recipe.GetDisplayName();
      descriptionText.text = recipe.GetDescription();

      //update ingredients list
      ingredientSlot1.UpdateIcon(recipe.ingredient1, recipe.quantity1);
      ingredientSlot2.UpdateIcon(recipe.ingredient2, recipe.quantity2);
      ingredientSlot3.UpdateIcon(recipe.ingredient3, recipe.quantity3);

    }



    public void CheckIfHaveAllIngredients()
    {

    }

    public void Brew()
    {

    }
  }
}
