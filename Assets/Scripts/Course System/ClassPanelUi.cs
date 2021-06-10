using TMPro;
using UI;

namespace Course_System
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
      currentClassToAttendNum = 1;
    }

    public void ButtonAttendingSecondClass() //for button class 2
    {
      currentClassToAttendNum = 2;
    }

    public void ButtonSkippingClass() //for button skipping class
    {
      //todo highlight the option chosen
      currentClassToAttendNum = 3;
      // print("class skipped");
      // CloseThisPanel();
    }

    public void ButtonConfirmToTakeThisClass()
    {

      ClassAttender.Instance.ConfirmTakingClass(currentClassToAttendNum);
      CloseThisPanel();
    }
  }
}
