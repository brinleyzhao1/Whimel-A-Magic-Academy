using System.Collections.Generic;
using GameDev.tv_Assets.Scripts.Inventories;
using Player.Interaction;
using UnityEngine;

namespace UI.Shop
{
  public class ShopMenu : UiPanelGeneric
  {
    [SerializeField] private Transform shopItemsContainer;


    public void SetUpShopList(List<InventoryItem> itemsForSell)
    {

      foreach (Transform child in shopItemsContainer.transform)
      {
        Destroy(child.gameObject);
      }


      if (shopItemsContainer == null)
      {
        Debug.LogError("inspector shopItemsContainer in ShopMenu is empty");
      }
      foreach (var item in itemsForSell)
      {
        GameObject newItem =  Instantiate(GameAssets.ShopItem, shopItemsContainer);
        newItem.GetComponent<ShopItemEntryUi>().SetUp(item);
      }
    }

  }
}
