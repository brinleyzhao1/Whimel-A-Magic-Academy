using System;
using GameDev.tv_Assets.Scripts.Inventories;
using GameDev.tv_Assets.Scripts.UI.Inventories;
using GameDevTV.Inventories;
using GameDevTV.UI.Inventories;
using UnityEngine;

namespace UI
{
  public class ChestInventoryUi : MonoBehaviour
  //copied from InventoryUI
  {
    // CONFIG DATA
    [SerializeField] InventorySlotUi InventoryItemPrefab = null;

    // CACHE
    Inventory chestInventory;

    // LIFECYCLE METHODS

    private void Awake()
    {
      // chestInventory = Inventory.GetPlayerInventory();
      // chestInventory.inventoryUpdated += Redraw;
    }

    public void SetThisChestInventory(Inventory thisChestInventory)
    {
      chestInventory = thisChestInventory;
      chestInventory.InventoryUpdated += Redraw;
    }

    // protected virtual void GetProperInventory()
    // {
    //   playerInventory = Inventory.GetPlayerInventory();
    //   playerInventory.inventoryUpdated += Redraw;
    // }

    private void Start()
    {
      Redraw();
    }

    // PRIVATE

    private void Redraw()
    {
      foreach (Transform child in transform)
      {
        Destroy(child.gameObject);
      }

      for (int i = 0; i < chestInventory.GetSize(); i++)
      {
        var itemUI = Instantiate(InventoryItemPrefab, transform);
        itemUI.Setup(chestInventory, i);
      }
    }
  }
}
