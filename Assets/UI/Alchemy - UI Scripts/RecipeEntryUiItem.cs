using Alchemy;
using Player.Interaction;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
  /// <summary>
  /// parallel to ShopItemEntryUi
  /// </summary>
  public class RecipeEntryUiItem : MonoBehaviour
  {
    // private string itemId;
    private PotionRecipeScriptableObject thisRecipe;

    [Header("from children")]
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI recipeNameText;
    // [SerializeField] private TextMeshProUGUI entryPriceText;


    public void SetUp(PotionRecipeScriptableObject recipe)
    {
      iconImage.sprite = recipe.GetIcon();
      recipeNameText.text = recipe.name;
      thisRecipe = recipe;
      // thisItem = item;
    }

    public void ButtonTellBrewToUpdateInfo()
    {
      GameAssets.BrewPanel.UpdateDisplayedInfo(thisRecipe);
    }
  }
}
