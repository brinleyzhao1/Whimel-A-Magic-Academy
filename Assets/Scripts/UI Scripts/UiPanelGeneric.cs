using Control;
using UI;
using UnityEngine;

namespace UI_Scripts
{
  public class UiPanelGeneric : MonoBehaviour
  {
    private void OnEnable()
    {
      FindObjectOfType<CursorChanger>().OneMoreUiOut();
    }

    public virtual void CloseThisPanel() //for button "Cancel"
    {
      CursorChanger.Instance.numberUiOut = 0;
      CursorChanger.Instance.OneLessUiOut(); //not sure why there are 2 ui out, bug?

      Time.timeScale = 1;

      CloseTabs();

      gameObject.SetActive(false);
    }

    private static void CloseTabs()
    {
      var tabs = FindObjectOfType<SwitchTabs>().gameObject;
      if (tabs)
      {
        tabs.SetActive(false);
      }
    }
  }
}
