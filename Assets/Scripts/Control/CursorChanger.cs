using System;
using Audio;
using Player.Interaction;
using Player.Movement;
using UnityEngine;
using UnityEngine.UI;

namespace Control
{
  /// <summary>
  /// has to sit on Player
  /// </summary>
  public class CursorChanger : MonoBehaviour
  {
    #region Singleton

    private static CursorChanger _instance;

    public static CursorChanger Instance => _instance;


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


    // [SerializeField] private Texture2D defaultCursor;
    public int numberUiOut = 0;


    [SerializeField] CursorMapping[] cursorMappings = null;

    [Serializable]
    struct CursorMapping
    {
      public CursorType type;
      public Sprite sprite;

      public Texture2D texture;
      // public Vector2 hotspot;
    }

    private void Start()
    {
      CursorChangeToFreeMode();
      // CursorChangeToLockedMode();

      // numberUiOut += 1; //the tutorial panel is out in the beginning
    }

    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.J))
      {
        print("number ui out = " + numberUiOut);
      }
    }

    /// <summary>
    /// for changing the central cross illusion of cursor in the middle of the screen
    /// </summary>
    /// <param name="cursorType"></param>
    public void SetCentralCursor(CursorType cursorType)
    {
      CursorMapping mapping = GetCursorMapping(cursorType);
      GameAssets.CenterCross.GetComponent<Image>().sprite = mapping.sprite;
    }

    /// <summary>
    /// for changing a free-moving cursor
    /// </summary>
    /// <param name="cursorType"></param>
    public void SetMovingCursor(CursorType cursorType)
    {
      CursorMapping mapping = GetCursorMapping(cursorType);
      Cursor.SetCursor(mapping.texture, new Vector2(0, 0), CursorMode.Auto);
    }


    public void OneMoreUiOut() //should only be called by ui's OnEnable
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

    /// <summary>
    /// forcefully clear out
    /// </summary>
    public void NoUiOut()
    {
      numberUiOut = 0;
      CursorChangeToFreeMode();
      AudioAssets.AudioSource.Play();
    }

    #region Private

    private CursorMapping GetCursorMapping(CursorType cursorType)
    {
      foreach (CursorMapping mapping in cursorMappings)
      {
        if (mapping.type == cursorType)
        {
          return mapping;
        }
      }

      return cursorMappings[0];
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

      Cursor.SetCursor(null, Vector2.zero, CursorMode.ForceSoftware);
    }

    #endregion
  }
}
