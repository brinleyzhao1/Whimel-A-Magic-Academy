using GameDev.tv_Assets.Scripts.Inventories;
using GameDevTV.Inventories;
using InventoryExample.Control;
using UnityEngine;

namespace Control
{
    [RequireComponent(typeof(Pickup))]
    public class ClickablePickup : MonoBehaviour
    {
        Pickup _pickup;

        private void Awake()
        {
            _pickup = GetComponent<Pickup>();
        }

        // public CursorType GetCursorType()
        // {
        //     if (pickup.CanBePickedUp())
        //     {
        //         return CursorType.Pickup;
        //     }
        //     else
        //     {
        //         return CursorType.FullPickup;
        //     }
        // }

        // public bool HandleRaycast(PlayerController callingController)
        // {
        //     if (Input.GetMouseButtonDown(0))
        //     {
        //         _pickup.PickupItem();
        //     }
        //     return true;
        // }

        private void OnMouseOver()
        {
          if (Input.GetMouseButtonDown(1))
          {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 10))
            {
              _pickup.PickupItem();
            }
          }
        }
    }
}
