using GameDev.tv_Assets.Scripts.Inventories;
using Library;
using Player;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{/// <summary>
 ///to be placed on the ui prefab bookOnShelf
 /// parallel to ShopItemEntryUi
 /// </summary>
  public class BookOnShelfEntryUi : MonoBehaviour
  {
    // private string itemId;
    private InventoryItem thisBook;

    [Header("from children")]
    [SerializeField] private Image entryImage;
    [SerializeField] private TMP_Text entryNameText;


    public void SetUp(BookItem book)
    {
      entryImage.sprite = book.GetIcon();
      entryNameText.text = book.GetDisplayName();
      thisBook = book;
    }

    public void ButtonSelectToRead()
    {
      var player = GameObject.FindGameObjectWithTag("Player");
      var inventory = player.GetComponent<Inventory>();
      inventory.AddToFirstEmptySlot(thisBook, 1);
      player.GetComponent<Money>().AddOrMinusMoney(-thisBook.buyingPrice);
    }
  }
}
