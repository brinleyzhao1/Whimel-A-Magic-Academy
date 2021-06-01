
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

      if (TimeManager.Hour >= 8 && TimeManager.Hour < 10)
      {
        _classAttendingUi.thisClass = class1;
        FindObjectOfType<CursorChanger>().CursorChangeToLockedMode();
        classMenuUi.SetActive(true);
        print("for class 1");
      }
      else if (TimeManager.Hour >= 10 && TimeManager.Hour <= 12)
      {
        _classAttendingUi.thisClass = class1; //todo will be class 2
        FindObjectOfType<CursorChanger>().CursorChangeToLockedMode();
        classMenuUi.SetActive(true);
      }

    }


  }
}
