using Control;
using Player.Interaction;
using UnityEngine;

namespace UI
{
  public class TriggerUi : MonoBehaviour
  {
    private void OnMouseOver()
    {
      if (Input.GetMouseButtonDown(1))
      {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 10))
        {
          FindObjectOfType<CursorChanger>().OneMoreUiOut();
          // FindObjectOfType<CursorChanger>().CursorChangeToLockedMode();
          WhenTriggered();
        }
      }
    }


    protected virtual void  WhenTriggered()
    {
      print("empty whenTriggered method");
    }
  }
}
