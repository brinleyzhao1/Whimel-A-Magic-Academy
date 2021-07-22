using Course_System;
using TMPro;

namespace UI_Scripts
{
  public class ClassPanelUi : UiPanelGeneric
  {
    private int currentClassToAttendNum;

    public TextMeshProUGUI class1Text;
    public TextMeshProUGUI class2Text;

    
    public void SetUpClassAttendingPanel(CourseItem class1, CourseItem class2)
    {
      class1Text.text = class1.name;
      class2Text.text = class2.name;
    }

    public void ButtonAttendingFirstClass() //for button class 1
    {
      // currentClassToAttendNum = 1;
      ClassAttender.Instance.ConfirmTakingClass(0);
      CloseThisPanel();
    }

    public void ButtonAttendingSecondClass() //for button class 2
    {
      // currentClassToAttendNum = 2;
      ClassAttender.Instance.ConfirmTakingClass(1);
      CloseThisPanel();
    }

    public void ButtonSkippingClass() //for button skipping class
    {
      currentClassToAttendNum = 2;
      ClassAttender.Instance.ConfirmTakingClass(2);
      CloseThisPanel();
      // print("class skipped");
      // CloseThisPanel();
    }

//     public void ButtonConfirmToTakeThisClass()
//     {
// //todo:  shouldn't be able to close the panel without choosing one of the options
//       ClassAttender.Instance.ConfirmTakingClass(currentClassToAttendNum);
//       CloseThisPanel();
//     }
  }
}
