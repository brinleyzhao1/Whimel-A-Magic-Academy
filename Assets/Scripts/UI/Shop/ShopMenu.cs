using System.Collections.Generic;
using GameDev.tv_Assets.Scripts.Inventories;
using Player.Interaction;
using UnityEngine;

namespace UI.Shop
{
  /// <summary>
  /// to be put on
  /// </summary>
  public class ShopMenu : UiPanelGeneric
  {
    [SerializeField] private Transform shopItemsContainer;


    public void SetUpShopList(List<InventoryItem> itemsForSell)
    {

      if (shopItemsContainer == null)
      {
        Debug.LogError("inspector shopItemsContainer in ShopMenu is empty");
      }

      foreach (Transform child in shopItemsContainer.transform)
      {
        Destroy(child.gameObject);
      }


      foreach (var item in itemsForSell)
      {
        if (item == null)
          continue;
        GameObject newItem =  Instantiate(GameAssets.ShopItem, shopItemsContainer);
        newItem.GetComponent<ShopItemEntryUi>().SetUp(item);
      }
    }

    public override void CloseThisPanel()
    {
      base.CloseThisPanel();
      GameAssets.SellTray.gameObject.SetActive(false);
    }
  }
}
