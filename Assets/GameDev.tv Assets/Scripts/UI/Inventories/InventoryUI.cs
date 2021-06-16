using GameDev.tv_Assets.Scripts.Inventories;
using GameDevTV.Inventories;
using UnityEngine;

namespace GameDev.tv_Assets.Scripts.UI.Inventories
{
  /// <summary>
  /// To be placed on the root of the inventory UI (gameObject "Inventory Items"). Handles spawning all the
  /// inventory slot prefabs.
  /// </summary>
  public class InventoryUi : MonoBehaviour
  {
    // CONFIG DATA
    [SerializeField] protected InventorySlotUi inventorySlotPrefab = null;

    // CACHE
    protected Inventory PlayerInventory;

    // LIFECYCLE METHODS

    private void Awake()
    {
      PlayerInventory = Inventory.GetPlayerInventory();
      PlayerInventory.InventoryUpdated += Redraw;
    }

    private void Start()
    {
      Redraw();
    }

    // PRIVATE

    protected virtual void Redraw()
    {
      foreach (Transform child in transform)
      {
        Destroy(child.gameObject);
      }

      for (int i = 0; i < PlayerInventory.GetSize(); i++)
      {
        var itemUi = Instantiate(inventorySlotPrefab, transform);
        itemUi.Setup(PlayerInventory, i);
      }
    }
  }
}
