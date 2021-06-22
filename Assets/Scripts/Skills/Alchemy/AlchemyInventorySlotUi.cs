using System;
using GameDev.tv_Assets.Scripts.Inventories;
using GameDev.tv_Assets.Scripts.UI.Inventories;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Alchemy
{
  public class AlchemyInventorySlotUi : MonoBehaviour, IPointerClickHandler
  {
    private AlchemySystem _alchemySystem;
    private InventorySlotUi _inventorySlotUi;

    private void OnEnable()
    {
      _alchemySystem = FindObjectOfType<AlchemySystem>();
      _inventorySlotUi = GetComponent<InventorySlotUi>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
      // tell alchemy system what ingredient has been added
      // -1 for this item in inventory
      InventoryItem item = _inventorySlotUi.GetItem();
      // print(item);
      _alchemySystem.AddIngredient(item);
      _alchemySystem.UpdateTrayUi();

      _inventorySlotUi.RemoveItems(1);

    }
  }
}
