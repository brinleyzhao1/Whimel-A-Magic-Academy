using GameDev.tv_Assets.Scripts.Inventories;
using GameDev.tv_Assets.Scripts.UI.Inventories;
using GameDevTV.Inventories;
using TMPro;
using UnityEngine;
// using UnityEngine.ProBuilder;

namespace Crafting
{
  public class CraftingInventoryUi : InventoryUi
  {
    // store a list of indexes of ingredients in inventory
    public CraftingSystem.CraftMode alchemyOrForge;


    private void Awake()
    {
      PlayerInventory = Inventory.GetPlayerInventory();
      PlayerInventory.InventoryUpdated += Redraw;
    }

    private void OnEnable()
    {
      Redraw();
      // UpdateIngredientList();
    }

    /// <summary>
    /// helper function
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    private bool CheckIsProperIngredient(InventoryItem item)
    {
      if (alchemyOrForge == CraftingSystem.CraftMode.Alchemy)
      {
        return item.isPotionIngredient;
      }
      if (alchemyOrForge == CraftingSystem.CraftMode.Forge)
      {
        return item.isForgeIngredient;
      }

      return false;
    }


    /// <summary>
    /// black out non-ingredients/materials
    /// </summary>
    protected override void Redraw()
    {
      // base.Redraw();
      foreach (Transform slot in transform)
      {
        if (slot.GetComponent<InventorySlotUi>().GetItem() == null)
        {
          continue;
        }

        if (slot.GetComponent<InventorySlotUi>().GetItem() != null)
        {
          InventoryItem item = slot.GetComponent<InventorySlotUi>().GetItem();

          if (item == null)
          {
            break;
          }

          bool isProperIngredient = CheckIsProperIngredient(item);

          if (isProperIngredient)
          {
            slot.GetComponent<CraftingInventorySlotUi>().enabled = true;
          }
          else
          {
            slot.GetComponent<InventorySlotUi>().GrayOut();
          }
        }
      }
    }
  }
}
