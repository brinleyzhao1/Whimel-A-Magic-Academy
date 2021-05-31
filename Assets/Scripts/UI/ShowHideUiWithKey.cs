using Control;
using Player.Movement;
using UnityEngine;

namespace UI
{
  public class ShowHideUiWithKey : MonoBehaviour
  {
    [SerializeField] KeyCode toggleKey = KeyCode.Escape;
    [SerializeField] GameObject uiContainer = null;
    private CursorChanger _cursorChanger;




    void Start()
    {
      uiContainer.SetActive(false);
      _cursorChanger = FindObjectOfType<CursorChanger>();
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(toggleKey))
      {
        OpenOrCloseTabs();

      }
    }

    public void OpenOrCloseTabs()
      {
        uiContainer.SetActive(!uiContainer.activeSelf);
        if (uiContainer.activeSelf)
        {
          _cursorChanger.OneMoreUiOut();
        }
        else
        {
          _cursorChanger.OneLessUiOut();
        }
      }
    }
  }
