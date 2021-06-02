
using System.Collections.Generic;
using Control;
using Course_System;
using Player;
using Player.Interaction;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;


namespace UI
{
  public class ClassAttendingUi : UiPanelGeneric
  {
    public CourseItem thisClass;

    private readonly Dictionary<string, int> statsChangeDictionary = new Dictionary<string, int>();

    private void OnEnable()
    {
      if (thisClass.courseName == null)
      {
        Debug.LogError("this course has no name!");
      }
      else if (thisClass == null)
      {
        Debug.LogError("thisClass has not been set");
      }
      else
      {
        transform.Find("Title/ClassName").GetComponent<TextMeshProUGUI>().text = thisClass.courseName;
      }
      FindObjectOfType<CursorChanger>().CursorChangeToLockedMode();
    }


    public void ConfirmAttendClass() //for button's use
    {

      GameAssets.ResultPanel.SetActive(true);

      DecideRandomStat();

      GameAssets.ResultPanel.GetComponent<ResultPanelUi>().Setup(statsChangeDictionary);
      FindObjectOfType<PlayerStats>().UpdateStatDictionary(statsChangeDictionary);


      gameObject.SetActive(false);

    }

    private void DecideRandomStat()
    {
      if (thisClass.listOfStats.Count != 3)
      {
        Debug.LogError(thisClass.courseName + "doesnt have 3 stats");
      }

      foreach (var stat in thisClass.listOfStats)
      {
        statsChangeDictionary.Add(stat.ToString(), Random.Range(1,5));
      }
    }
  }
}
