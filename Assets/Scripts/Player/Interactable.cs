using System;
using Player;
using UnityEngine;

public class Interactable : MonoBehaviour
{
  public float radius = 3f;
  // private bool _isFocused = false;
  PlayerInteract _player;

  private void Start()
  {
    _player = FindObjectOfType<PlayerInteract>();
  }

  private void OnMouseOver()
  {
    if (Input.GetMouseButtonDown(1))
    {
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hit;

      if (Physics.Raycast(ray, out hit, 10))
      {
        print("interact");
        // _player.SetFocus(this);

        // Interactable interactable = hit.collider.GetComponent<Interactable>();
        // if (interactable != null)
        // {
        //   _player.SetFocus(interactable);
        // }
      }
    }
  }
   private void Update()
   {
     // if (_isFocused)
     // {
     //   float distance = Vector3.Distance(_player.transform.position, transform.position);
     //   if (distance < radius)
     //   {
     //     print("interact");
     //   }

     }
   // }

   // public void OnFocused(PlayerInteract playerTransform)
   // {
   //   _isFocused = true;
   //   _player = playerTransform;
   // }
   //
   // public void OnDeFocused()
   // {
   //   _isFocused = false;
   //   _player = null;
   // }

  private void OnDrawGizmosSelected()
  {
    Gizmos.color = Color.yellow;
    Gizmos.DrawWireSphere(transform.position, radius);
  }
}

