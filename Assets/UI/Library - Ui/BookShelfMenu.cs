
using System.Collections.Generic;
using Library;
using UnityEngine;

namespace UI
{
  /// <summary>
  /// to be put on ui Book Shelf Menu, reflects a list of books contained
  /// </summary>
  public class BookShelfMenu : MonoBehaviour
  {

    [SerializeField] private Transform shopItemsContainer;


    public void SetUpShopList(List<BookItem> booksInThisShelf)
    {
    //
    //   if (shopItemsContainer == null)
    //   {
    //     Debug.LogError("inspector shopItemsContainer in ShopMenu is empty");
    //   }
    //
    //   foreach (Transform child in shopItemsContainer.transform)
    //   {
    //     Destroy(child.gameObject);
    //   }
    //
    //
    //   foreach (var item in booksInThisShelf)
    //   {
    //     if (item == null)
    //       continue;
    //     GameObject newItem =  Instantiate(GameAssets.ShopItem, shopItemsContainer);
    //     newItem.GetComponent<ShopItemEntryUi>().SetUp(item);
    //   }
    // }
    //
    // public override void CloseThisPanel()
    // {
    //   base.CloseThisPanel();
    //   GameAssets.SellTray.gameObject.SetActive(false);
    }
  }
}
