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
