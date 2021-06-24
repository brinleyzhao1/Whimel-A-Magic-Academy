using Alchemy;
using Player.Interaction;
using UI;

namespace Crafting
{
  public class AlchemyUiTrigger : TriggerUi
  {

    protected override void WhenTriggered()
    {
      GameAssets.PotionPanel.gameObject.SetActive(true);
      var knownList = KnownPotionRecipesStorage.Instance.knownPotionRecipes;
      GameAssets.RecipeBookPanel.GetComponent<PotionRecipeBookUi>().SetUpRecipeBook(knownList);
      // GameAssets.ShopPanel.GetComponent<ShopMenu>().SetUpShopList(itemsForSell);
      // FindObjectOfType<ShowHideUiWithKey>().OpenOrCloseTabs();
      // FindObjectOfType<SwitchTabs>().SwitchToInventoryTab();
    }


  }
}
