using System;
using Player.Interaction;
using UnityEngine;
using Control;

namespace UI_Scripts
{
  public class Interactable : MonoBehaviour
  {
    public float interactableRadius = 5f;
    [SerializeField] private CursorType cursorType = CursorType.UiCursor;

    private GameObject player;

    // private bool _isFocused = false;
    private void Start()
    {
      player = GameAssets.Player;
    }

    private void OnMouseOver()
    {
      float distance = Vector3.Distance(player.transform.position, transform.position);


      if (distance < interactableRadius) //todo: if within range AND facing the interactable
      {
        //present [E]
        CursorChanger.Instance.SetCentralCursor(cursorType);
        GameAssets.InteractHint.gameObject.SetActive(true);

        if (Input.GetKeyDown(KeyCode.F))
        {
          Interact();
        }
      }
      else
      {
        GameAssets.InteractHint.gameObject.SetActive(false);
      }

      if (Input.GetMouseButtonDown(1))
      {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactableRadius))
        {
          Interact();
        }
      }
    }

    private void OnMouseExit()
    {
      GameAssets.InteractHint.gameObject.SetActive(false);
      CursorChanger.Instance.SetCentralCursor(CursorType.None);
    }


    protected virtual void Interact()
    {
      print("empty whenTriggered method");
    }
  }
}
