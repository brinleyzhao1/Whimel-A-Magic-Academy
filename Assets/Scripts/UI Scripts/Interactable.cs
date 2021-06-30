using System;
using Player.Interaction;
using UnityEngine;
using Control;

namespace UI_Scripts
{
  public class Interactable : MonoBehaviour
  {
    public float keyInteractableRadius = 5f;
    public float clickInteractableRadius = 5f;
    [SerializeField] private CursorType cursorType = CursorType.UiCursor;

    private GameObject player;

    // private bool _isFocused = false;
    private void Start()
    {
      player = GameAssets.Player;
    }

    private void OnMouseOver()
    {
      CursorChanger.Instance.SetCentralCursor(cursorType);

      //if within interactableRadius, can interact
      float distance = Vector3.Distance(player.transform.position, transform.position);
      if (distance < keyInteractableRadius) //todo: if within range AND facing the interactable
      {
        //present [E]
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

        if (Physics.Raycast(ray, out hit, clickInteractableRadius))
        {
          Interact();
        }
      }
    }

    private void OnMouseExit()
    {
      CursorChanger.Instance.SetCentralCursor(CursorType.None);
    }


    protected virtual void Interact()
    {
      print("empty whenTriggered method");
    }
  }
}
