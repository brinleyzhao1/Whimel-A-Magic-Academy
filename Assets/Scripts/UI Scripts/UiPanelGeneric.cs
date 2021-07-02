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
      CursorChanger.Instance.OneLessUiOut();
      CursorChanger.Instance.OneLessUiOut();//not sure why there are 2 ui out, bug?


      Time.timeScale = 1;

      if (FindObjectOfType<SwitchTabs>())
      {
        CloseTabs();
      }

      gameObject.SetActive(false);
    }

    private static void CloseTabs()
    {
      var tabs = FindObjectOfType<SwitchTabs>().gameObject;
      if (tabs.activeSelf)
      {
        tabs.SetActive(false);
      }
    }
  }
}
