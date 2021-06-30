using System.Collections.Generic;
using GameDev.tv_Assets.Scripts.Inventories;
using Player.Interaction;
using UI;
using UI_Scripts.Shop;
using UI.Shop;
using UnityEngine;

namespace UI_Scripts.Dining
{
  /// <summary>
  /// parallel to shopMenu, sit on ui diningMenu
  /// </summary>
  public class DiningMenu : UiPanelGeneric
  {
    [SerializeField] private Transform diningItemsContainer;

    //todo: abstraction, with ShopMenu

    public void SetUpDiningList(List<ActionScriptableItem> foodProvided)
    {

      if (diningItemsContainer == null)
      {
        Debug.LogError("inspector diningItemsContainer in DiningMenu is empty");
      }

      foreach (Transform child in diningItemsContainer.transform)
      {
        Destroy(child.gameObject);
      }

print(1);

      foreach (var item in foodProvided)
      {
        if (item == null)
          continue;
        GameObject newItem =  Instantiate(GameAssets.DiningItem, diningItemsContainer);
        newItem.GetComponent<DiningItemEntryUi>().SetUp(item);
      }
    }


  }
}
