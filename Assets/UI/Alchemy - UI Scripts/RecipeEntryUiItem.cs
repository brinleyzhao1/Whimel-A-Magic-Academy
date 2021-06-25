using Alchemy;
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
      // entryPriceText.text = item.buyingPrice.ToString();
      // // transform.GetChild(0).GetComponent<Image>().sprite = item.GetIcon();
      // // transform.GetChild(1).GetComponent<TMP_Text>().text = item.name;
      // // transform.GetChild(3).GetComponent<TMP_Text>().text = item.buyingPrice.ToString();
      //
      // thisItem = item;
    }
  }
}
