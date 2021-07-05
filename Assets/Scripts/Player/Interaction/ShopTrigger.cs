using System.Collections.Generic;
using Control;
using GameDev.tv_Assets.Scripts.Inventories;
using UI;
using UI_Scripts;
using UI_Scripts.Shop;

namespace Player.Interaction
{
  public class ShopTrigger : Interactable
  {
    public List<InventoryItem> itemsForSell = new List<InventoryItem>();


    protected override void Interact()
    {
      FindObjectOfType<CursorChanger>().OneMoreUiOut();
      GameAssets.ShopPanel.gameObject.SetActive(true);
      GameAssets.ShopPanel.GetComponent<ShopMenu>().SetUpShopList(itemsForSell);
      FindObjectOfType<ShowHideUiWithKey>().OpenOrCloseTabs();
      FindObjectOfType<SwitchTabs>().SwitchToInventoryTab();


      GameAssets.SellTray.gameObject.SetActive(true);

    }

  }
}
