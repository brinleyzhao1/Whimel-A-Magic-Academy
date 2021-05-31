using System;
using System.Collections.Generic;
using Course_System;
using Endings;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameDev.tv_Assets.Scripts.UI.Courses
{
  public class OneCoursePanel : MonoBehaviour
  {

    /// <summary>
    ///  mimics "Inventory", this stores courseItems listed for one panel
    /// </summary>
    ///
    ///
    private List<EndingItem> listedCourses;
    private EndingItem _selectedEnding;
    [SerializeField] private int courseSlotIndex;
    [SerializeField] private int fallOrSpring = 0;
    // private PanelUI _panelUi;
    [SerializeField] CourseButton courseItemPrefab = null;
    private Transform courseItems;

    [SerializeField] private TextMeshProUGUI selecctedCourseText;

    ///
    ///
    // STATE
    // CourseItem[] allListedCourses;


    // /// <summary>
    // /// Broadcasts when the courses in the cart are changed.
    // /// </summary>
    // public event Action cartUpdated;

    /// <summary>
    /// How many slots are in the inventory?
    /// </summary>
    public int GetSize()
    {
      // return allListedCourses.Length;
      return listedCourses.Count;
    }

    private void Awake()
    {
      // courseItems = GetComponentInChildren<ContentSizeFitter>().transform;
      // listedCourses = FindObjectOfType<CourseTranscript>().CalculateThisSemesterCatalog(fallOrSpring, courseSlotIndex);
      // Redraw(courseItems);
    }

    public void ChangeSelection(EndingItem ending)
    {
      _selectedEnding = ending;
      // Redraw();
      FindObjectOfType<CourseCart>().UpdateCart(courseSlotIndex, ending);
      // _panelUi.Redraw();

      selecctedCourseText.text = ending.name;
    }

    public void Redraw(Transform courseItems)
    {
        foreach (Transform child in courseItems)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < listedCourses.Count; i++)
        {
            var courseButton = Instantiate(courseItemPrefab, courseItems);
            courseButton.SetItem(listedCourses[i]);
        }
    }
  }
}
