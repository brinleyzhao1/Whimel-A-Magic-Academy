using Alchemy;
using Control;
using Player.Interaction;
using UI;
using UI_Scripts;

namespace Crafting
{
  public class AlchemyUiTrigger : Interactable
  {

    protected override void Interact()
    {
      FindObjectOfType<CursorChanger>().OneMoreUiOut();
      GameAssets.PotionPanel.gameObject.SetActive(true);
      var knownList = Alchemy.Alchemy.Instance.knownPotionRecipes;
      GameAssets.RecipeBookPanel.GetComponent<PotionRecipeBookUi>().SetUpRecipeBook(knownList);
      // GameAssets.ShopPanel.GetComponent<ShopMenu>().SetUpBookShelf(itemsForSell);
      // FindObjectOfType<ShowHideUiWithKey>().OpenOrCloseTabs();
      // FindObjectOfType<SwitchTabs>().SwitchToInventoryTab();
    }


  }
}
