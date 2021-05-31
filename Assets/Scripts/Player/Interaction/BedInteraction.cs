using Control;
using UI;
using UnityEngine;

namespace Player.Interaction
{
  public class BedInteraction : TriggerUi
  {
    // private void OnMouseOver()
    // {
    //   if (Input.GetMouseButtonDown(1))
    //   {
    //     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    //     RaycastHit hit;
    //
    //     if (Physics.Raycast(ray, out hit, 10))
    //     {
    //       // print("hit bed");
    //       GameAssets.sleepPanel.gameObject.SetActive(true);
    //       FindObjectOfType<CursorChanger>().CursorChangeToLockedMode();
    //     }
    //   }
    // }

    protected override void WhenTriggered()
    {
      GameAssets.sleepPanel.gameObject.SetActive(true);
      // FindObjectOfType<CursorChanger>().CursorChangeToLockedMode();
    }
  }
}
