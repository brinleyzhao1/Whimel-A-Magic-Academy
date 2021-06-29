using System.Collections.Generic;
using Library;
using UI;
using UnityEngine;

namespace Player.Interaction
{
  public class BookShelfTrigger : TriggerUi
  {
    public int schoolYearRequired = 1;
    public List<BookItem> booksInThisShelf = new List<BookItem>();


    protected override void WhenTriggered()
    {
      int currentSchoolYear = TimeManager.Year;

      //only unlock if above a certain schoolYear
      if (currentSchoolYear >= schoolYearRequired)
      {
        GameAssets.BookShelfPanel.gameObject.SetActive(true);
        GameAssets.BookShelfPanel.GetComponent<BookShelfMenu>().SetUpBookShelf(booksInThisShelf);
      }
      else
      {
        GameAssets.MessagePanel.gameObject.SetActive(true);
        GameAssets.MessagePanel.SetMessageText("Sorry, this book shelf will unlock to you at school year " +
                                               schoolYearRequired);
      }
    }
  }
}
