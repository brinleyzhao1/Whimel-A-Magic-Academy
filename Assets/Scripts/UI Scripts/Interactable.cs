using Player.Interaction;
using UnityEngine;

namespace UI_Scripts
{
  public class Interactable : MonoBehaviour
  {
    public float keyInteractableRadius = 5f;
    public float clickInteractableRadius = 5f;

    private GameObject player;

    // private bool _isFocused = false;
    private void Start()
    {
      player = GameAssets.Player;
    }

    private void OnMouseOver()
    {
      //if within interactableRadius, can interact
      float distance = Vector3.Distance(player.transform.position, transform.position);
      if (distance < keyInteractableRadius) //todo: question - should interactableRadius be the same for clicking?
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


    protected virtual void Interact()
    {
      print("empty whenTriggered method");
    }
  }
}
