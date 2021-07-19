using Control;
using GameDev.tv_Assets.Scripts.Utils;
using SceneManagement;
using TMPro;
using UnityEngine;

namespace UI_Scripts.Menus
{
  public class MainMenuUi : MonoBehaviour
  {
    LazyValue<SavingWrapper> savingWrapper;

    [SerializeField] TMP_InputField newGameNameField;

    private void Awake()
    {

      savingWrapper = new LazyValue<SavingWrapper>(GetSavingWrapper);
      // CursorChanger.Instance.OneMoreUiOut();
    }

    private SavingWrapper GetSavingWrapper()
    {
      return FindObjectOfType<SavingWrapper>();
    }

    public void ContinueGame() //for button
    {
      savingWrapper.value.ContinueGame();
    }

    public void NewGame()
    {
      savingWrapper.value.NewGame(newGameNameField.text);
    }

    public void QuitGame()
    {
      #if UNITY_EDITOR
      UnityEditor.EditorApplication.isPlaying = false;
      #else
            Application.Quit();
        #endif
    }
  }
}
