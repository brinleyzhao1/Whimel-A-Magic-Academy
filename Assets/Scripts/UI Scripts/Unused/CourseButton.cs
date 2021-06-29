using System;
using Course_System;
using Endings;
using TMPro;
using UnityEngine;

namespace GameDev.tv_Assets.Scripts.UI.Courses
{
  public class CourseButton : MonoBehaviour
  {
    private bool selected = false;
    private OneCoursePanel _oneCoursePanel;
    private EndingItem _thisEnding;

    private void Start()
    {
      _oneCoursePanel = GetComponentInParent<OneCoursePanel>();

    }


    /// <summary>
    /// update text based on item
    /// </summary>
    /// <param name="ending"></param>
    public void SetItem(EndingItem ending)
    {
      foreach(Behaviour component in GetComponents<Behaviour>()){
        component.enabled = true;
      }

      _thisEnding = ending;
      var courseText = GetComponentInChildren<TextMeshProUGUI>();
      courseText.enabled = true;
      courseText.text = ending.name;

    }

    public void BeenClicked()
    {
      selected = !selected;
      //tell panel selectedcourse is updated
      _oneCoursePanel.ChangeSelection(_thisEnding);

      // if (selected)
      // {
        // GetComponent<Image>().color = Color.cyan;

      // }
      // else
      // {
        // GetComponent<Image>().color = Setting.instance.elementColorDictionary[_elementID];//
      // }

    }
  }
}
