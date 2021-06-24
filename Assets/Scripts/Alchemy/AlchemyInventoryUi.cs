// using GameDev.tv_Assets.Scripts.Inventories;
// using GameDev.tv_Assets.Scripts.UI.Inventories;
// using GameDevTV.Inventories;
// using UnityEngine;
//
// namespace Alchemy
// {
//   public class AlchemyInventoryUi : InventoryUi
//   {
//     // store a list of indexes of ingredients in inventory
//
//     private void Awake()
//     {
//       PlayerInventory = Inventory.GetPlayerInventory();
//       PlayerInventory.InventoryUpdated += Redraw;
//     }
//
//     private void OnEnable()
//     {
//       Redraw();
//       // UpdateIngredientList();
//     }
//
//
//     protected override void Redraw()
//     {
//       base.Redraw();
//       foreach (Transform slot in transform)
//       {
//         if (slot.GetComponent<InventorySlotUi>().GetItem() != null)
//         {
//           InventoryItem item = slot.GetComponent<InventorySlotUi>().GetItem();
//           if (item == null)
//           {
//             break;
//           }
//
//           bool isPotionIngredient = item.isPotionIngredient;
//
//           if (isPotionIngredient)
//           {
//             slot.GetComponent<AlchemyInventorySlotUi>().enabled = true;
//           }
//           else
//           {
//             slot.GetComponent<InventorySlotUi>().GrayOut();
//           }
//         }
//       }
//     }
//   }
// }
