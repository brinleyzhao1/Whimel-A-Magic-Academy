using GameDev.tv_Assets.Scripts.Inventories;
using GameDev.tv_Assets.Scripts.UI.Inventories;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Crafting
{
  public class CraftingInventorySlotUi : MonoBehaviour, IPointerClickHandler
  {
    private CraftingSystem _craftingSystem;
    private InventorySlotUI _inventorySlotUi;

    private void OnEnable()
    {
      _craftingSystem = FindObjectOfType<CraftingSystem>();
      _inventorySlotUi = GetComponent<InventorySlotUI>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
      // tell alchemy system what ingredient has been added
      // -1 for this item in inventory
      InventoryItem item = _inventorySlotUi.GetItem();
      // print(item);
      _craftingSystem.AddIngredientOnClick(item);
      _craftingSystem.UpdateTrayUi();

      _inventorySlotUi.RemoveItems(1);

    }
  }
}
