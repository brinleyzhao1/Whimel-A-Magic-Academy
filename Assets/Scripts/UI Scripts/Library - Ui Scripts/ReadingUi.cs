using System.Collections;
using Audio;
using Control;
using GameDev.tv_Assets.Scripts.Inventories;
using Library;
using Player.Interaction;
using Skills;
using Stats;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI_Scripts
{
  /// <summary>
  /// responsible for updating bookDetailBoard with the book selected and read button
  /// </summary>
  public class ReadingUi : UiPanelGeneric
  {
    private BookItem thisBook;

    [Range(0, 1)][SerializeField] private float chanceToFindRecipe = .5f;

    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI nameText;

    [SerializeField] private TextMeshProUGUI descriptionText;

    // [SerializeField] private TextMeshProUGUI lvlText;
    [SerializeField] private TextMeshProUGUI timeText;

    public bool inProcessOfReading;

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


    public override void CloseThisPanel()
    {
      if (inProcessOfReading)
      {
        AudioAssets.AudioSource.PlayOneShot(AudioAssets.Error);
        return;
      }

      base.CloseThisPanel();
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
      PlayerStats.Instance.UpdateOneStatByValue(thisBook.statReward1.rewardStatsType, thisBook.statReward1.level);
      PlayerSkills.Instance.AddExperienceToSkill(thisBook.expReward2.rewardSkill, thisBook.expReward2.expValue);

      TimeManager.Instance.FastForwardByRealLifeSeconds(thisBook.timeNeedToRead);

      SetUpBookDetail(thisBook); //refresh the visual, especially the timer

      ChanceToFindRecipe();

      inProcessOfReading = false;
    }

    private void ChanceToFindRecipe()
    {
      if (Random.value <= chanceToFindRecipe)
      {
        var recipeFound = Alchemy.Alchemy.Instance.GetNextRecipe();
        GameAssets.PlayerInventory.AddToFirstEmptySlot(recipeFound,1);

        GameAssets.MessagePanel.gameObject.SetActive(true);
        GameAssets.MessagePanel.SetMessageText("Congratulations! you found a new recipe!");
        print(recipeFound);

      }
      else
      {
        print("failed to find");
      }
    }

    public void CancelReading()
    {
      StopCoroutine(Read());
    }
  }
}
