using System.Collections.Generic;
using GameDev.tv_Assets.Scripts.Inventories;
using UI;
using UI_Scripts.Shop;
using UI.Shop;

namespace Player.Interaction
{
  public class ShopTrigger : TriggerUi
  {
    public List<InventoryItem> itemsForSell = new List<InventoryItem>();


    protected override void WhenTriggered()
    {
      GameAssets.ShopPanel.gameObject.SetActive(true);
      GameAssets.ShopPanel.GetComponent<ShopMenu>().SetUpShopList(itemsForSell);
      FindObjectOfType<ShowHideUiWithKey>().OpenOrCloseTabs();
      FindObjectOfType<SwitchTabs>().SwitchToInventoryTab();


      GameAssets.SellTray.gameObject.SetActive(true);

    }

  }
}
