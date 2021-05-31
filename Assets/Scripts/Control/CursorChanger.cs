using System;
using System.Net.NetworkInformation;
using Player.Movement;
using UnityEngine;

namespace Control
{
  public class CursorChanger : MonoBehaviour
  {
    [SerializeField] private Texture2D menuCursor;
    public int numberUiOut = 0;


    public void OneMoreUiOut()
    {
      numberUiOut += 1;
      // print("+, " +  numberUiOut);
    }

    public void OneLessUiOut()
    {
      numberUiOut -= 1;
      if (numberUiOut < 0)
      {
        numberUiOut = 0;
      }

      // print("-, " +  numberUiOut);
    }

    private void Update()
    {
      if (numberUiOut == 0)
      {
        //todo also close tabs off if it's opened
        CursorChangeToFreeMode();
      }
      else
      {
        CursorChangeToLockedMode();

      }
    }

    private void Start()
    {
      CursorChangeToFreeMode(); //todo
      // print(numberUiOut);
    }

    public void CursorChangeToFreeMode()
    {
      Cursor.lockState = CursorLockMode.Locked;
      Cursor.visible = false;
      GetComponent<MouseLookX>().enabled = true;
      GetComponentInChildren<MouseLookY>().enabled = true;

    }

    public void CursorChangeToLockedMode()
    {
      Cursor.lockState = CursorLockMode.None;
      Cursor.visible = true;
      GetComponent<MouseLookX>().enabled = false;
      GetComponentInChildren<MouseLookY>().enabled = false;
      Cursor.SetCursor(menuCursor, Vector2.zero, CursorMode.ForceSoftware);


    }
  }
}
