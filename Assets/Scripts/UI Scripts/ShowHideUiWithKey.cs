using System;
using Audio;
using Control;
using UnityEngine;

namespace UI_Scripts
{
  public class ShowHideUiWithKey : MonoBehaviour
  {
    [SerializeField] KeyCode toggleKey = KeyCode.Escape;
    [SerializeField] GameObject tabsContainer = null;
    [SerializeField] GameObject customaryUiContainer = null;
    private CursorChanger _cursorChanger;


    void Start()
    {
      tabsContainer.SetActive(false);
      _cursorChanger = CursorChanger.Instance;
    }

    // Update is called once per frame
    void Update()
    {
      //todo testing purpose
      RaycastHit hit;
      // // Does the ray intersect any objects excluding the player layer
      // if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity))
      // {
      //   Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
      //   Debug.Log("Did Hit "+ transform.name);
      // }
      // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      // if(Physics.Raycast(ray, out hit))
      // {
      //   Debug.Log(hit.transform.name);
      // }


      if (Input.GetKeyDown(toggleKey))
      {
        OpenOrCloseTabs();
      }



      //if any ui is open, press F to close all
      if (_cursorChanger.numberUiOut > 0)
      {
        if (Input.GetKeyDown(KeyCode.Q))
        {
          CloseAllCustomaryUis();

        }
      }
    }

    public void OpenOrCloseTabs()
    {
      tabsContainer.SetActive(!tabsContainer.activeSelf);
      if (tabsContainer.activeSelf)
      {
        _cursorChanger.OneMoreUiOut();
      }
      else
      {
        _cursorChanger.OneLessUiOut();
      }
    }

    private void CloseAllCustomaryUis()
    {
      foreach (Transform child in customaryUiContainer.transform)
      {
        child.gameObject.SetActive(false);
        _cursorChanger.NoUiOut();
      }

    }
  }
}
