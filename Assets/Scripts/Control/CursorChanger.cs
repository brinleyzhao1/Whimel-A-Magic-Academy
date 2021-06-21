using System;
using System.Net.NetworkInformation;
using Player.Movement;
using UnityEngine;

namespace Control
{
  /// <summary>
  /// has to sit on Player
  /// </summary>
  public class CursorChanger : MonoBehaviour
  {
    #region Singleton

    private static CursorChanger _instance;

    public static CursorChanger Instance
    {
      get { return _instance; }
    }


    private void Awake()
    {
      if (_instance != null && _instance != this)
      {
        Destroy(this.gameObject);
      }
      else
      {
        _instance = this;
      }
    }

    #endregion


    [SerializeField] private Texture2D menuCursor;
    public int numberUiOut = 0;


    public void OneMoreUiOut()
    {
      numberUiOut += 1;
      CursorChangeToLockedMode();
      // print("+, " +  numberUiOut);
    }

    public void OneLessUiOut()
    {
      numberUiOut -= 1;
      if (numberUiOut < 0)
      {
        numberUiOut = 0;
      }

      if (numberUiOut == 0)
      {
        //todo also close tabs off if it's opened
        CursorChangeToFreeMode();
      }

      // print("-, " +  numberUiOut);
    }

    // private void Update()
    // {
    //   if (numberUiOut == 0)
    //   {
    //     //todo also close tabs off if it's opened
    //     CursorChangeToFreeMode();
    //   }
    //   else
    //   {
    //     CursorChangeToLockedMode();
    //
    //   }
    // }

    private void Start()
    {
      CursorChangeToFreeMode();
      // CursorChangeToLockedMode(); //because of the main menu UI
    }

    private void CursorChangeToFreeMode()
    {
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
      GetComponent<MouseLookX>().enabled = true;
      GetComponentInChildren<MouseLookY>().enabled = true;
    }

    private void CursorChangeToLockedMode()
    {
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
      GetComponent<MouseLookX>().enabled = false;
      GetComponentInChildren<MouseLookY>().enabled = false;
      Cursor.SetCursor(menuCursor, Vector2.zero, CursorMode.ForceSoftware);
    }
  }
}
