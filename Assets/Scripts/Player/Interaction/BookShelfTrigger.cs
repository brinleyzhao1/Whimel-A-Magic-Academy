using System.Collections.Generic;
using Library;
using UI;
using UnityEngine;

namespace Player.Interaction
{
  public class BookShelfTrigger : TriggerUi
  {
    public List<BookItem> booksInThisShelf = new List<BookItem>();


    protected override void WhenTriggered()
    {
      GameAssets.BookShelfPanel.gameObject.SetActive(true);
      GameAssets.ShopPanel.GetComponent<BookShelfMenu>().SetUpShopList(booksInThisShelf);


    }

  }
}
