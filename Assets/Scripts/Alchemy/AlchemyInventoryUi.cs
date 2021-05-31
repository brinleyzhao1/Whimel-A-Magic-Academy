using GameDev.tv_Assets.Scripts.Inventories;
using GameDev.tv_Assets.Scripts.UI.Inventories;
using GameDevTV.Inventories;
using UnityEngine;

namespace Alchemy
{
  public class AlchemyInventoryUi : InventoryUI
  {
    // store a list of indexes of ingredients in inventory

    private void Awake()
    {
      playerInventory = Inventory.GetPlayerInventory();
      playerInventory.inventoryUpdated += Redraw;
    }

    private void OnEnable()
    {
      Redraw();
      // UpdateIngredientList();
    }


    protected override void Redraw()
    {
      base.Redraw();
      foreach (Transform slot in transform)
      {
        if (slot.GetComponent<InventorySlotUI>().GetItem() != null)
        {
          InventoryItem item = slot.GetComponent<InventorySlotUI>().GetItem();
          if (item == null)
          {
            break;
          }

          bool isPotionIngredient = item.isPotionIngredient;

          if (isPotionIngredient)
          {
            slot.GetComponent<AlchemyInventorySlotUi>().enabled = true;
          }
          else
          {
            slot.GetComponent<InventorySlotUI>().GrayOut();
          }
        }
      }
    }
  }
}
