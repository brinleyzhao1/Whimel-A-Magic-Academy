using Alchemy;
using Player.Interaction;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
  public class BrewingUi : MonoBehaviour
  {
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI descriptionText;


    [Header("ingredient slot UIs")] [SerializeField]
    private IngredientSlotUi ingredientSlot1;

    [SerializeField] private IngredientSlotUi ingredientSlot2;
    [SerializeField] private IngredientSlotUi ingredientSlot3;

    [SerializeField] private Button brewButton;
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

      if (!CheckIfHaveAllIngredients(recipe))
      {
        brewButton.gameObject.GetComponent<Image>().color = Color.gray;
        brewButton.onClick = null;
      }
      else
      {
        brewButton.gameObject.GetComponent<Image>().color = Color.white;
        brewButton.onClick.AddListener(ButtonBrew);
      }
    }


    public void ButtonBrew()
    {
      print("potion brewed");
      //wait some seconds / animation
      //subtract all ingredients from inventory
      //add final potion to inventory

    }

    public bool CheckIfHaveAllIngredients(PotionRecipeScriptableObject recipe)
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
  }
}
