using Player.Interaction;
using UI;

namespace Crafting
{
  public class AlchemyUiTrigger : TriggerUi
  {

    protected override void WhenTriggered()
    {
      GameAssets.PotionPanel.gameObject.SetActive(true);
      // GameAssets.ShopPanel.GetComponent<ShopMenu>().SetUpShopList(itemsForSell);
      // FindObjectOfType<ShowHideUiWithKey>().OpenOrCloseTabs();
      // FindObjectOfType<SwitchTabs>().SwitchToInventoryTab();
    }


  }
}
