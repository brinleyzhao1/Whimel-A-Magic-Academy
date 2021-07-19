using Control;
using SceneManagement;
using UnityEngine;

namespace UI_Scripts
{
  public class PauseMenuUi : MonoBehaviour
  {

    private void OnEnable()
    {
      //pause time
      Time.timeScale = 0;
    }

    private void OnDisable()
    {
      //unpause time
      Time.timeScale = 1;
      CursorChanger.Instance.OneLessUiOut();
    }

    public void ButtonReturnToMainMenu()
    {
      //save
     var savingWrapper =  FindObjectOfType<SavingWrapper>();
     // savingWrapper.Save	();
     savingWrapper.LoadMenu();

    }


  }
}
