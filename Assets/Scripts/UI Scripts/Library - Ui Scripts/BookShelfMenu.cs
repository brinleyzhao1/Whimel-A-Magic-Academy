using System.Collections.Generic;
using Library;
using Player.Interaction;
using UnityEngine;

namespace UI_Scripts
{
  /// <summary>
  /// to be put on ui Book Shelf Menu, reflects a list of books contained
  /// parallel to shopMenu
  /// </summary>
  public class BookShelfMenu : UiPanelGeneric
  {
    [SerializeField] private Transform bookItemsContainer;


    public void SetUpBookShelf(List<BookItem> booksInThisShelf)
    {
      if (bookItemsContainer == null)
      {
        Debug.LogError("inspector bookItemsContainer in ShopMenu is empty");
      }

      foreach (Transform child in bookItemsContainer.transform)
      {
        Destroy(child.gameObject);
      }


      foreach (var item in booksInThisShelf)
      {
        if (item == null)
          continue;
        GameObject newItem = Instantiate(GameAssets.BookOnShelfPrefab, bookItemsContainer);
        newItem.GetComponent<BookOnShelfEntryUi>().SetUp(item);
      }
    }

    public override void CloseThisPanel()
    {

      base.CloseThisPanel();
      // GameAssets.SellTray.gameObject.SetActive(false);
    }
  }
}
