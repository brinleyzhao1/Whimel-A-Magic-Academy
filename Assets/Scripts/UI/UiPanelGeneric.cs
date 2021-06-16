using System;
using Control;
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
      gameObject.SetActive(false);
      FindObjectOfType<CursorChanger>().OneLessUiOut();
      FindObjectOfType<CursorChanger>().numberUiOut = 0;

     if(FindObjectOfType<SwitchTabs>())
     {
       CloseTabs();
     }

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
