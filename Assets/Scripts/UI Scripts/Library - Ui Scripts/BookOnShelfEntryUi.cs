using Library;
using Player.Interaction;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Scripts
{/// <summary>
 ///to be placed on the ui prefab bookOnShelf
 /// parallel to ShopItemEntryUi
 /// </summary>
  public class BookOnShelfEntryUi : MonoBehaviour
  {
    // private string itemId;
    private BookItem thisBook;

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
     GameAssets.BookDetailPanel.SetActive(true);
     GameAssets.BookDetailPanel.GetComponent<BookDetailBoardUi>().SetUpBookDetail(thisBook);

    }
  }
}
