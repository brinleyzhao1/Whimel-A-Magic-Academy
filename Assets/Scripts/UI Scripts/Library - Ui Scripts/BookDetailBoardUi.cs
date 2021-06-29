using System.Collections;
using System.Collections.Generic;
using Library;
using Player;
using Player.Interaction;
using Skills;
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
    [SerializeField] private TextMeshProUGUI timeText;

    public void SetUpBookDetail(BookItem book)
    {
      iconImage.sprite = book.GetIcon();
      nameText.text = book.GetDisplayName();
      descriptionText.text = book.GetDescription();
      lvlText.text = "lvl: " + book.level;
      timeText.text = book.timeNeedToRead + "s";
      //todo typeText
      thisBook = book;
    }

    public void ButtonReadThisBook() //activity
    {
      StartCoroutine(Read());
    }

    IEnumerator Read()
    {
      //todo: limit players from reading when a reading activity is already going on

      //wait some seconds / animation
      yield return StartCoroutine(TimeManager.Instance.CountDownWithText(thisBook.timeNeedToRead, timeText));

      //after countdown, reward player
      //todo: for now add each by hand, might want to consider using a list in the future
      PlayerStats.Instance.UpdateOneStatByValue(thisBook.statReward1.rewardStats, thisBook.statReward1.value);
      PlayerSkills.Instance.AddExperienceToSkill(thisBook.expReward2.rewardSkill, thisBook.expReward2.expValue);
      
    }
  }
}
