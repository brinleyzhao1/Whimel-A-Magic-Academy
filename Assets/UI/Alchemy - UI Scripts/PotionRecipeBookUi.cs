using System.Collections.Generic;
using Alchemy;
using Player.Interaction;
using UnityEngine;

namespace UI
{/// <summary>
 /// in charge of updating the recipe book on current learnt recipes
 /// sort of parallel to shopMenu
 /// </summary>
  public class PotionRecipeBookUi : MonoBehaviour
  {[SerializeField] private Transform recipeUiItemsContainer = null;


    public void SetUpRecipeBook(List<PotionRecipeScriptableObject> knownRecipes)
    {

      if (recipeUiItemsContainer == null)
      {
        Debug.LogError("inspector recipeUiItemsContainer in PotionRecipeBookUi is empty");
      }

      foreach (Transform child in recipeUiItemsContainer.transform)
      {
        Destroy(child.gameObject);
      }


      foreach (var item in knownRecipes)
      {
        if (item == null)
          continue;
        GameObject newItem =  Instantiate(GameAssets.RecipeItemUi, recipeUiItemsContainer);
        newItem.GetComponent<RecipeEntryUiItem>().SetUp(item);
      }
    }


  }
}
