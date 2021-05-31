
using Control;
using UI;
using UnityEngine;

namespace Course_System
{
  public class ClassAttender : MonoBehaviour
  {

    [SerializeField] private CourseItem class1; //todo
    [SerializeField] private CourseItem class2;


    [SerializeField] private GameObject classMenuUi;
    private ClassAttendingUI _classAttendingUi;



    private void Start()
    {
      _classAttendingUi = classMenuUi.GetComponent<ClassAttendingUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
      OpenCorrespondingClassPanelIfClassTime();
    }

    private void OpenCorrespondingClassPanelIfClassTime()
    {

      if (TimeManager.hour >= 8 && TimeManager.hour < 10)
      {
        _classAttendingUi.thisClass = class1;
        FindObjectOfType<CursorChanger>().CursorChangeToLockedMode();
        classMenuUi.SetActive(true);
        print("for class 1");
      }
      else if (TimeManager.hour >= 10 && TimeManager.hour <= 12)
      {
        _classAttendingUi.thisClass = class1; //todo will be class 2
        FindObjectOfType<CursorChanger>().CursorChangeToLockedMode();
        classMenuUi.SetActive(true);
      }

    }


  }
}
