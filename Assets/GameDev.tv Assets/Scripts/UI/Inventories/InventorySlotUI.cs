using GameDev.tv_Assets.Scripts.Inventories;
using GameDev.tv_Assets.Scripts.Utils.UI.Dragging;
using GameDevTV.Inventories;
using GameDevTV.UI.Inventories;
using UnityEngine;

namespace GameDev.tv_Assets.Scripts.UI.Inventories
{
  public class InventorySlotUi : MonoBehaviour, IItemHolder, IDragContainer<InventoryItem>
  {
    // CONFIG DATA
    [SerializeField] InventoryItemIcon icon = null; // own child
    [SerializeField] GameObject gray;

    // STATE
    public int index;
    InventoryItem item;
    Inventory inventory;

    // PUBLIC

    public void Setup(Inventory inventory, int index)
    {
      this.inventory = inventory;
      this.index = index;
      icon.SetItem(inventory.GetItemInSlot(index), inventory.GetNumberInSlot(index));
    }

    public int MaxAcceptable(InventoryItem item)
    {
      if (inventory.HasSpaceFor(item))
      {
        return int.MaxValue;
      }

      return 0;
    }

    public void AddItems(InventoryItem item, int number)
    {
      inventory.AddItemToSlot(index, item, number);
    }

    public InventoryItem GetItem()
    {
      return inventory.GetItemInSlot(index);
    }

    public int GetNumber()
    {
      return inventory.GetNumberInSlot(index);
    }

    public void RemoveItems(int number)
    {
      inventory.RemoveFromSlot(index, number);
    }


    public void GrayOut()
    {
      //transform.Find("grayMask").gameObject.SetActive(true);
    }


    //------ sell system

    // void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
    // {
    //   if (GameAssets.ShopPanel.activeSelf)
    //   {
    //     GameAssets.SellingTray.SetActive(true);


    // foreach (var sellItem in transform.parent.GetComponentsInChildren<SellItem>())
    // {
    //   sellItem.enabled = false;
    // }
    //
    // GetComponent<SellItem>().enabled = true;
    // }

    // }
  }
}
