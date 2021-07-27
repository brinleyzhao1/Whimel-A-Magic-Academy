using Audio;
using Control;
using Player.Interaction;
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
      // CursorChanger.Instance.NoUiOut();
      CursorChanger.Instance.OneLessUiOut(); //not sure why there are 2 ui out, bug?

      Time.timeScale = 1;

      GameAssets.TabsContainer.SetActive(false);

      AudioAssets.AudioSource.PlayOneShot(AudioAssets.Paper);

      gameObject.SetActive(false);

    }


  }
}
