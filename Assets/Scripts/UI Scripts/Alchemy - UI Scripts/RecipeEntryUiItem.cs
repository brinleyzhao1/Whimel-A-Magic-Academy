using Alchemy;
using Player.Interaction;
using Skills;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Scripts
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

      int playerAlchemyLevel = PlayerSkills.Instance.GetAlchemyLevel();
      if (recipe.level > playerAlchemyLevel+1)
      {
        recipeNameText.color = Color.gray;
      }
    }

    public void ButtonTellBrewToUpdateInfo()
    {
      GameAssets.BrewPanel.UpdateDisplayedInfo(thisRecipe);
    }
  }
}
