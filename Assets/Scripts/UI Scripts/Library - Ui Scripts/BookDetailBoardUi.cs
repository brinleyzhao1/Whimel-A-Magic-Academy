using Library;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Scripts
{
  /// <summary>
  /// responsible for updating bookDetailBoard with the book selected and read button
  /// </summary>
  public class BookDetailBoardUi : MonoBehaviour
  {
    private BookItem thisBook;

    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI lvlText;

    public void SetUpBookDetail(BookItem book)
    {
      iconImage.sprite = book.GetIcon();
      nameText.text = book.GetDisplayName();
      descriptionText.text = book.GetDescription();
      lvlText.text = "lvl: " + book.level;
      //todo typeText
      thisBook = book;
    }

    public void ButtonReadThisBook()//activity
    {

    }
  }
}
