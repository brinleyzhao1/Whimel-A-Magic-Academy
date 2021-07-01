using System;
using Control;
using Player.Interaction;
using UnityEngine;

namespace UI
{
  public class UiPanelGeneric : MonoBehaviour
  {
    private void OnEnable()
    {
      FindObjectOfType<CursorChanger>().OneMoreUiOut();
    }

    public virtual void CloseThisPanel() //for button "Cancel"
    {
      print("close panel");

      CursorChanger.Instance.OneLessUiOut();
      CursorChanger.Instance.OneLessUiOut();//not sure why there are 2 ui out, bug?
      print(CursorChanger.Instance.numberUiOut);
      // FindObjectOfType<CursorChanger>().
      // FindObjectOfType<CursorChanger>().numberUiOut = 0;

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
