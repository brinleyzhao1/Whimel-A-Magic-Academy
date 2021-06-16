using System;
using GameDev.tv_Assets.Scripts.Inventories;
using GameDev.tv_Assets.Scripts.Utils.UI.Dragging;
using GameDevTV.Inventories;
using GameDevTV.UI.Inventories;
using UI.Shop;
using UnityEngine;
using UnityEngine.EventSystems;

namespace GameDev.tv_Assets.Scripts.UI.Inventories
{
  public class InventorySlotUi : MonoBehaviour, IItemHolder, IDragContainer<InventoryItem>, ISelectHandler
  {
    // CONFIG DATA
    [SerializeField] InventoryItemIconInChild iconInChild = null; // own child
    [SerializeField] GameObject gray;

     private SellTray sellTray;

    // STATE
    public int index;
    InventoryItem item;
    Inventory inventory;


    private void Start()
    {
      sellTray = FindObjectOfType<SellTray>();
    }
    // PUBLIC

    public void Setup(Inventory inventory, int index)
    {
      this.inventory = inventory;
      this.index = index;
      iconInChild.SetItem(inventory.GetItemInSlot(index), inventory.GetNumberInSlot(index));
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

    /// <summary>
    /// select for sell tray
    /// </summary>
    /// <param name="eventData"></param>
    public void OnSelect(BaseEventData eventData)
    {
      //tell sell tray what item and how many
      sellTray.ReceiveInfoAboutSelectedItemForSell(index, inventory.GetItemInSlot(index),
        inventory.GetNumberInSlot(index));
    }
  }
}
