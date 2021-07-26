using System.Collections;
using Library;
using Skills;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Scripts
{
  /// <summary>
  /// responsible for updating bookDetailBoard with the book selected and read button
  /// </summary>
  public class ReadingUi : MonoBehaviour
  {
    private BookItem thisBook;

    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    // [SerializeField] private TextMeshProUGUI lvlText;
    [SerializeField] private TextMeshProUGUI timeText;

    private bool inProcessOfReading;

    public void SetUpBookDetail(BookItem book)
    {
      iconImage.sprite = book.GetIcon();
      nameText.text = book.GetDisplayName();
      descriptionText.text = book.GetDescription();
      // lvlText.text = "lvl: " + book.level;
      timeText.text = book.timeNeedToRead + "s";
      //todo typeText
      thisBook = book;
    }

    public void ButtonReadThisBook() //activity
    {
      if (!inProcessOfReading)
      {
        StartCoroutine(Read());
      }

      // int bookLevel = thisBook.bookLevel;
      // int playerKnowledge = PlayerStats.Instance.GetKnowledge();

    }

    private IEnumerator Read()
    {
      inProcessOfReading = true;
      //wait some seconds / animation
      yield return StartCoroutine(TimeManager.Instance.CountDownWithText(thisBook.timeNeedToRead, timeText));

      //after countdown, reward player
      //todo: for now add each by hand, might want to consider using a list in the future
      //todo: read book reward stat
      // PlayerStats.Instance.UpdateOneStatByLevel(thisBook.statReward1.rewardStatsType, thisBook.statReward1.level,true);
      PlayerSkills.Instance.AddExperienceToSkill(thisBook.expReward2.rewardSkill, thisBook.expReward2.expValue);

      TimeManager.Instance.FastForwardByRealLifeSeconds(thisBook.timeNeedToRead);

      SetUpBookDetail(thisBook); //refresh the visual, especially the timer

      inProcessOfReading = false;
    }

    public void CancelReading()
    {
      StopCoroutine(Read());
    }
  }
}
